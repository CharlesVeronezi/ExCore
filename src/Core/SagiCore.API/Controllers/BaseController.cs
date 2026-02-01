using Microsoft.AspNetCore.Mvc;
using SagiCore.Communication.Responses;

namespace SagiCore.API.Controllers;

/// <summary>
/// Controller base com métodos padronizados de resposta
/// </summary>
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult ApiOk<T>(T data, string message = "Operação realizada com sucesso")
        => Ok(ApiResponse<T>.Success(data, message));

    protected IActionResult ApiCreated<T>(T data, string message = "Recurso criado com sucesso")
        => StatusCode(201, ApiResponse<T>.Created(data, message));

    protected IActionResult ApiNoContent(string message = "Operação realizada com sucesso")
        => Ok(ApiResponse.Success(message, 204));

    protected IActionResult ApiBadRequest(string message, IList<string>? errors = null)
        => BadRequest(ApiResponse<object>.Fail(message, 400, errors));

    protected IActionResult ApiNotFound(string message = "Recurso não encontrado")
        => NotFound(ApiResponse<object>.Fail(message, 404));

    protected IActionResult ApiUnauthorized(string message = "Não autorizado")
        => Unauthorized(ApiResponse<object>.Fail(message, 401));
}