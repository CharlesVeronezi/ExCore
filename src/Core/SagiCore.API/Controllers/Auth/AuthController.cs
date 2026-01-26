using Microsoft.AspNetCore.Mvc;
using SagiCore.Auth.Application.UseCases;
using SagiCore.Communication.Requests.Auth;

namespace SagiCore.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(
        [FromServices] LoginUseCase useCase,
        [FromBody] RequestLoginJson request)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
