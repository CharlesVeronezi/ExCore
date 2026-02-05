using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SagiCore.Communication.Responses;
using SagiCore.Exceptions;
using SagiCore.Exceptions.ExceptionsBase;
using System.Net;

namespace SagiCore.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is SagiCoreException sagiException)
        {
            HandleProjectException(context, sagiException);
        }
        else
        {
            ThrowUnknownException(context);
        }

        context.ExceptionHandled = true;
    }

    private void HandleProjectException(ExceptionContext context, SagiCoreException exception)
    {
        // Log estruturado com nível apropriado para exceções de negócio
        _logger.LogWarning(
            "Exceção de negócio: {ExceptionType} - {Message} | Path: {Path}",
            exception.GetType().Name,
            exception.Message,
            context.HttpContext.Request.Path);

        switch (exception)
        {
            case ErrorOnValidationException validationEx:
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(
                    ApiResponse<object>.Fail("Erro de validação", 400, validationEx.ErrorMessages));
                break;

            case InvalidLoginException:
                // Log de segurança para tentativas de login inválidas
                _logger.LogWarning(
                    "Tentativa de login inválida | IP: {IP} | UserAgent: {UserAgent}",
                    context.HttpContext.Connection.RemoteIpAddress,
                    context.HttpContext.Request.Headers.UserAgent);
                
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new UnauthorizedObjectResult(
                    ApiResponse<object>.Fail("Credenciais inválidas", 401));
                break;

            default:
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(
                    ApiResponse<object>.Fail(exception.Message, 400));
                break;
        }
    }

    private void ThrowUnknownException(ExceptionContext context)
    {
        // Log completo com stack trace para erros inesperados
        _logger.LogError(
            context.Exception,
            "Erro não tratado: {Message} | Path: {Path} | Method: {Method}",
            context.Exception.Message,
            context.HttpContext.Request.Path,
            context.HttpContext.Request.Method);

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(
            ApiResponse<object>.Fail(ResourceMessagesException.UNKNOWN_ERROR, 500))
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}