using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SagiCore.Communication.Responses;
using SagiCore.Exceptions;
using SagiCore.Exceptions.ExceptionsBase;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;

namespace SagiCore.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           if (context.Exception is SagiCoreException)
           {
                // Tratar exceções customizadas da aplicação
                HandleProjectException(context);
            }
           else
           {
                // Tratar exceções genéricas
                ThrowUnknowException(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException) 
            {
                var exception = context.Exception as ErrorOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErrorMessages));
            }
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
           
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOWN_ERROR));
            
        }
    }
}
