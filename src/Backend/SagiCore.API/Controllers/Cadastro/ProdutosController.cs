using Microsoft.AspNetCore.Mvc;
using SagiCore.Application.UseCases.Cadastro.Produto.Registrar;
using SagiCore.Communication.Requests;
using SagiCore.Communication.Responses;

namespace SagiCore.API.Controllers.Cadastro
{
    [Route("/cadastro/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredProdutoJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar(
            [FromServices]IRegisterProdutoUseCase useCase,
            [FromBody]RequestRegisterProdutoJson request)
        {

            var result = await useCase.Executar(request);

            return Created(string.Empty, result);
        }
    }
}
