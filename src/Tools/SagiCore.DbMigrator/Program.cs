using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SagiCore.DbMigrator;
using SagiCore.DbMigrator.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var host = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            config.AddJsonFile("appsettings.json", optional: true);
            config.AddEnvironmentVariables();
        })
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<MigrationEngine>();
            services.AddSingleton<Worker>();
        })
        .UseSerilog()
        .Build();

    // Executa e encerra
    var worker = host.Services.GetRequiredService<Worker>();
    worker.Execute();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Erro fatal na inicialização do Migrator");
}
finally
{
    Log.CloseAndFlush();
}