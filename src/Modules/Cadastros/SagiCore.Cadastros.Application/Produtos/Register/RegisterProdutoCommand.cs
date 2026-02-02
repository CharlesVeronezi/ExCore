using SagiCore.Communication.Responses.Cadastro.Produto;
using SagiCore.Shared.Application.Abstractions;

namespace SagiCore.Cadastros.Application.Produtos.Register
{
    public record RegisterProdutoCommand(
        string Codpro,
        string Subcod,
        string Produto,
        string Unidade,
        string TipoProduto,
        string Ncm,
        bool Diverso,
        int CodigoCategoria,
        string TipoPesquisa,
        string? CodigoReferencia1 = null,
        string? CodigoReferencia2 = null
    ) : IUseCase<ResponseRegisteredProdutoJson>;
}
