using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SagiCore.Domain.Repositories;
using SagiCore.Infrastructure.DataAccess;
using SagiCore.Infrastructure.DataAccess.Repositories;

namespace SagiCore.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            AddDbContext(services, connectionString);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection service, string connectionString)
        {
            service.AddDbContext<SagiCoreDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseNpgsql(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection service)
        {

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<IProdutoWriteRepository, ProdutoRepository>();
            service.AddScoped<IProdutoReadRepository, ProdutoRepository>();
        }
    }
}
