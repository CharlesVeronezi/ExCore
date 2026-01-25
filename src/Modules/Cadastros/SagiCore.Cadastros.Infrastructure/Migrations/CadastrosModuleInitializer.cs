using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace SagiCore.Cadastros.Infrastructure.Migrations
{
    public static class CadastrosModuleInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}
