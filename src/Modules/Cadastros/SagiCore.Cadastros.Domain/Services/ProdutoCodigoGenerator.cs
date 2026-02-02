using SagiCore.Cadastros.Domain.Repositories;

namespace SagiCore.Cadastros.Domain.Services;

public sealed class ProdutoCodigoGenerator : IProdutoCodigoGenerator
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoCodigoGenerator(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<(string Codpro, string Subcod)> GerarCodigoSeNecessarioAsync(
        string? codpro, 
        string? subcod, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(codpro))
        {
            var proximoCodigo = await _produtoRepository.GerarProximoCodigoAsync(cancellationToken);
            return (proximoCodigo, "S");
        }

        return (codpro, subcod ?? "S");
    }
}