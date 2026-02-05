using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace SagiCore.Shared.Infrastructure.Logging;

public static class SerilogExtensions
{
    public static IHostBuilder UseSagiCoreSerilog(this IHostBuilder hostBuilder)
    {
        return hostBuilder.UseSerilog((context, services, configuration) =>
        {
            var env = context.HostingEnvironment;
            
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .Enrich.WithProperty("Application", "SagiCore.API")
                .Enrich.WithProperty("Version", typeof(SerilogExtensions).Assembly.GetName().Version?.ToString() ?? "1.0.0");

            if (env.IsProduction())
            {
                configuration.WriteTo.Async(a => a.Console(new CompactJsonFormatter()));
            }
            else
            {
                // Development: output legível para humanos
                configuration.WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext}{NewLine}" +
                                   "      {Message:lj}{NewLine}" +
                                   "      Props: {Properties}{NewLine}" + 
                                   "{Exception}");
            }

            // Utiliza WriteTo.Async para não bloquear a thread principal em disco lento
            var logPath = context.Configuration["Logging:FilePath"] ?? "logs/sagicore-.log";
            
            configuration.WriteTo.Async(a => a.File(
                path: logPath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 15,
                formatter: new CompactJsonFormatter()));

            // Filtros de ruído
            configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
            configuration.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information);
            configuration.MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning);
        });
    }

    /// <summary>
    /// Configura a ordem correta dos middlewares de log.
    /// </summary>
    public static IApplicationBuilder UseSagiCoreRequestLogging(this IApplicationBuilder app)
    {
        // 1. Correlation ID deve ser o primeiro para cobrir todo o ciclo
        app.UseMiddleware<CorrelationIdMiddleware>();
        
        // 2. Tenant Logger depende de autenticação, idealmente viria APÓS UseAuthentication/Authorization
        app.UseMiddleware<TenantLoggerMiddleware>();

        // 3. Log padrão de requisições HTTP do Serilog (substitui o log padrão do ASP.NET)
        app.UseSerilogRequestLogging(options =>
        {
            options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
            {
                diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                diagnosticContext.Set("ClientIP", httpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown");
                diagnosticContext.Set("UserAgent", httpContext.Request.Headers.UserAgent.ToString());
            };
            
            // Mensagem limpa de request
            options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} respondeu {StatusCode} em {Elapsed:0.0000} ms";
            
            // Não logar health checks ou assets estáticos
            options.GetLevel = (httpContext, elapsed, ex) => 
                (httpContext.Request.Path.Value?.Contains("/health") == true) 
                ? LogEventLevel.Verbose 
                : LogEventLevel.Information;
        });
        
        return app;
    }
}