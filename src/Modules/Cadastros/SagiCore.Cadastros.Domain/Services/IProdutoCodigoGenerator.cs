namespace SagiCore.Cadastros.Domain.Services;

public interface IProdutoCodigoGenerator
{
    Task<(string Codpro, string Subcod)> GerarCodigoSeNecessarioAsync(
        string? codpro, 
        string? subcod, 
        CancellationToken cancellationToken = default);
}