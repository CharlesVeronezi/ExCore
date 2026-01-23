using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SagiCore.Cadastros.Domain.Repositories;
using SagiCore.Cadastros.Infrastructure.Persistence;
using SagiCore.Cadastros.Infrastructure.Persistence.Repositories;
using SagiCore.Shared.Domain.Repositories;
using SagiCore.Shared.Infrastructure.Persistence;
using System.Reflection;

namespace SagiCore.Cadastros.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCadastrosInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<CadastrosDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            // Registrar UnitOfWork para este contexto
            services.AddScoped<IUnitOfWork>(sp =>
                new UnitOfWork<CadastrosDbContext>(sp.GetRequiredService<CadastrosDbContext>()));

            // Registrar repositórios
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoReadRepository>(sp => sp.GetRequiredService<IProdutoRepository>());
            services.AddScoped<IProdutoWriteRepository>(sp => sp.GetRequiredService<IProdutoRepository>());

            // FluentMigrator Runner
            services.AddFluentMigratorCore().ConfigureRunner(builder =>
            {
                builder
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    // Carrega as migrations do assembly de Infrastructure
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations();
            });

            return services;
        }
    }
}
