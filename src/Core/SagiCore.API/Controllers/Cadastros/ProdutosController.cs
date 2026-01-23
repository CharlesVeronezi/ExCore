using MediatR;
using Microsoft.AspNetCore.Mvc;
using SagiCore.Cadastros.Application.Produtos.Register;
using SagiCore.Communication.Responses;
using SagiCore.Communication.Responses.Cadastro.Produto;

namespace SagiCore.API.Controllers.Cadastros
{
    [Route("api/cadastros/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredProdutoJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Registrar(
            [FromBody] RegisterProdutoCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, result);
        }
    }
}
