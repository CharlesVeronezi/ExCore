using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SagiCore.Cadastros.Infrastructure.Migrations;

namespace SagiCore.DbMigrator.Services
{
    public class MigrationEngine
    {
        private readonly ILogger<MigrationEngine> _logger;

        public MigrationEngine(ILogger<MigrationEngine> logger)
        {
            _logger = logger;
        }

        public void Run(string databaseName, string connectionString)
        {
            _logger.LogInformation("Iniciando migração para o banco: {Database}", databaseName);

            var serviceProvider = CreateServices(connectionString);
            using var scope = serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            try
            {
                if (runner.HasMigrationsToApplyUp())
                {
                    runner.MigrateUp();
                    _logger.LogInformation("Banco {Database} migrado com sucesso!", databaseName);
                }
                else
                {
                    _logger.LogInformation("Banco {Database} já está atualizado.", databaseName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro crítico ao migrar {Database}", databaseName);
                throw;
            }
        }

        private IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    // IMPORTANTE: Adicionar aqui os Assemblies de TODOS os módulos que têm migrations
                    .ScanIn(typeof(CadastrosModuleInitializer).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}
