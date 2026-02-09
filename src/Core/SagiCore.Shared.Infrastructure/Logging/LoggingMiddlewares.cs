using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using SagiCore.Shared.Application.User;
using Serilog.Context;

namespace SagiCore.Shared.Infrastructure.Logging;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private const string CorrelationIdHeader = "X-Correlation-Id";

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var correlationId = GetCorrelationId(context);
        
        // Adiciona o ID no log context para aparecer em TODAS as linhas de log dessa request
        using (LogContext.PushProperty("CorrelationId", correlationId))
        {
            // Retorna o ID no header de resposta para facilitar debug do frontend/cliente
            context.Response.OnStarting(() =>
            {
                context.Response.Headers[CorrelationIdHeader] = new[] { (string)correlationId };
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }

    private static StringValues GetCorrelationId(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue(CorrelationIdHeader, out var correlationId))
        {
            return correlationId;
        }

        return Guid.NewGuid().ToString();
    }
}

/// <summary>
/// Middleware focado em extrair dados do Contexto do Usuário/Request 
/// e injetá-los no LogContext do Serilog de forma segura.
/// </summary>
public class TenantLoggerMiddleware
{
    private readonly RequestDelegate _next;

    public TenantLoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserContext userContext)
    {
        var tenantId = "Anonymous";
        try
        {
             if(context.User.Identity?.IsAuthenticated == true)
             {
                 var id = userContext.GetIdEmpresa();
                 tenantId = id.ToString();
             }
        }
        catch 
        { 
            // Ignora erro de resolução de tenant no log para não quebrar a request
        }

        using (LogContext.PushProperty("TenantId", tenantId))
        {
            await _next(context);
        }
    }
}