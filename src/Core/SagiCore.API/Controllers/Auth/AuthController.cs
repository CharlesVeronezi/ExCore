using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SagiCore.Auth.Application.UseCases;
using SagiCore.Communication.Requests.Auth;
using SagiCore.Communication.Responses;
using SagiCore.Communication.Responses.Auth;

namespace SagiCore.API.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    /// <summary>
    /// Realiza login e retorna o token JWT
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<ResponseLoginJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromServices] LoginUseCase useCase,
        [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);
        return ApiOk(response, "Login realizado com sucesso");
    }
}
