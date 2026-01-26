using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using SagiCore.DbMigrator.Entities;
using SagiCore.DbMigrator.Services;
using System.Data;

namespace SagiCore.DbMigrator
{
    public class Worker
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;
        private readonly MigrationEngine _migrationEngine;

        public Worker(IConfiguration configuration, ILogger<Worker> logger, MigrationEngine migrationEngine)
        {
            _configuration = configuration;
            _logger = logger;
            _migrationEngine = migrationEngine;
        }

        public void Execute()
        {
            _logger.LogInformation(">>> Iniciando SagiCore DbMigrator <<<");

            // 1. Conectar no Autentica
            var authConnectionString = _configuration.GetConnectionString("ConnectionAutentica");
            if (string.IsNullOrEmpty(authConnectionString))
            {
                throw new Exception("ConnectionStrings:ConnectionAutentica não encontrada.");
            }

            IEnumerable<TenantConnection> tenants;
            try
            {
                using IDbConnection db = new NpgsqlConnection(authConnectionString);
                // st_isat = true garante que só pegamos clientes ativos
                tenants = db.Query<TenantConnection>(@"
                SELECT id, database, host, port, ""user"", password 
                FROM public.conexao_cliente_cloud");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Falha ao conectar no servidor AUTENTICA. Abortando.");
                return;
            }

            // 2. Iterar sobre os clientes
            _logger.LogInformation("Encontrados {Count} clientes ativos para migração.", tenants.Count());

            foreach (var tenant in tenants)
            {
                try
                {
                    var connectionString = tenant.GetConnectionString();
                    _migrationEngine.Run(tenant.Database, connectionString);
                }
                catch (Exception)
                {
                    // Log feito no Engine. Continuamos para o próximo cliente para não parar todo o processo.
                    _logger.LogWarning("Pulando cliente {Database} devido a erro.", tenant.Database);
                }
            }

            _logger.LogInformation(">>> Processo de migração finalizado <<<");
        }
    }
}
