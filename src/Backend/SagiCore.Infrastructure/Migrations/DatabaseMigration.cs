using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace SagiCore.Infrastructure.Migrations

{
    public class DatabaseMigration
    {
        public static void Migrate(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            
            runner.ListMigrations();
            runner.MigrateUp();
        }
    }
}
