namespace SagiCore.Cadastros.Domain.Repositories;

public interface IUnidadeRepository
{
    Task<bool> ExisteAsync(string un, CancellationToken cancellationToken = default);
}