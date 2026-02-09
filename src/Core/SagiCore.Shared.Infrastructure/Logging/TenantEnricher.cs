using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System.Security.Claims;

namespace SagiCore.Shared.Infrastructure.Logging;

/// <summary>
/// Enricher que adiciona informações do tenant (IdEmpresa) e usuário a cada log.
/// </summary>
public class TenantEnricher : ILogEventEnricher
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantEnricher(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        
        if (httpContext?.User?.Identity?.IsAuthenticated == true)
        {
            var idEmpresa = httpContext.User.FindFirst("IdEmpresa")?.Value ?? "Unknown";
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? "Unknown";
            var userName = httpContext.User.FindFirst("Usuario")?.Value ?? "Unknown";

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("TenantId", idEmpresa));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserEmail", userEmail));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", userName));
        }
        else
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("TenantId", "Anonymous"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserEmail", "Anonymous"));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserName", "Anonymous"));
        }
    }
}