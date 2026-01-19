using Microsoft.AspNetCore.Mvc;
using SagiCore.Application.UseCases.Operacional.PedidoVenda.Register;
using SagiCore.Communication.Requests.Operacional.PedidoVenda;
using SagiCore.Communication.Responses.Operacional.PedidoVenda;

namespace SagiCore.API.Controllers.Operacional
{
    [Route("operacional/[controller]")]
    [ApiController]
    public class PedidoVendaController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredPedidoVendaJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterPedidoVendaUseCase useCase,
            [FromBody] RequestRegisterPedidoVendaJson request)
        {

            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
