using Microsoft.AspNetCore.Mvc;
using SagiCore.Application.UseCases.Cadastro.Produto.Register;
using SagiCore.Communication.Requests.Cadastro.Produto;
using SagiCore.Communication.Responses.Cadastro.Produto;

namespace SagiCore.API.Controllers.Cadastro
{
    [Route("/cadastro/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredProdutoJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromServices]IRegisterProdutoUseCase useCase,
            [FromBody]RequestRegisterProdutoJson request)
        {

            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
