using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SagiCore.Cadastros.Application.Produtos.Register;
using SagiCore.Communication.Responses;
using SagiCore.Communication.Responses.Cadastro.Produto;

namespace SagiCore.API.Controllers.Cadastros;

[Route("api/cadastros/[controller]")]
[Authorize]
[ApiController]
public class ProdutosController : BaseController
{
    private readonly IMediator _mediator;

    public ProdutosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registra um novo produto
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<ResponseRegisteredProdutoJson>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Registrar(
        [FromBody] RegisterProdutoCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return ApiCreated(result, "Produto registrado com sucesso");
    }
}
