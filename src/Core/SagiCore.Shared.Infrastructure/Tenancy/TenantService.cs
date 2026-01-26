using Dapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Npgsql;
using SagiCore.Shared.Application.Tenancy;
using SagiCore.Shared.Application.User;

namespace SagiCore.Shared.Infrastructure.Tenancy
{
    public class TenantService : ITenantService
    {
        private readonly IUserContext _userContext;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private const string CachePrefix = "TENANT_CONN_";

        public TenantService(IUserContext userContext, IConfiguration configuration, IMemoryCache cache)
        {
            _userContext = userContext;
            _configuration = configuration;
            _cache = cache;
        }

        public async Task<string> GetConnectionStringAsync()
        {
            var idEmpresa = _userContext.GetIdEmpresa();
            var cacheKey = $"{CachePrefix}{idEmpresa}";

            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                return await BuscarNoBancoAutentica(idEmpresa);
            }) ?? throw new Exception($"Configuração de banco de dados não encontrada para a Empresa {idEmpresa}");
        }

        private async Task<string> BuscarNoBancoAutentica(int idEmpresa)
        {
            var connStringAutentica = _configuration.GetConnectionString("ConnectionAutentica");

            using var connection = new NpgsqlConnection(connStringAutentica);

            var dados = await connection.QueryFirstOrDefaultAsync<dynamic>(
                @"SELECT host, port, database, ""user"", password 
              FROM conexao_cliente_cloud 
              WHERE idempresa = @IdEmpresa",
                new { IdEmpresa = idEmpresa });

            if (dados == null) return null;

            return $"Host={dados.host};Port={dados.port};Database={dados.database};Username={dados.user};Password={dados.password}";
        }
    }
}
