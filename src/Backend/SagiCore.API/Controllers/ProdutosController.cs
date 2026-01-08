using Microsoft.AspNetCore.Mvc;
using SagiCore.Application.UseCases.Produto.Registrar;
using SagiCore.Communication.Requests;
using SagiCore.Communication.Responses;

namespace SagiCore.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseProdutoRegistradoJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar(
            [FromServices]IRegistrarProdutoUseCase useCase,
            [FromBody]RequestRegistrarProdutoJson request)
        {

            var result = await useCase.Executar(request);

            return Created(string.Empty, result);
        }
    }
}
