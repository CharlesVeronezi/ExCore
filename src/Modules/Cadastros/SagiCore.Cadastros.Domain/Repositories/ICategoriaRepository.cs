using SagiCore.Cadastros.Domain.Entities;

namespace SagiCore.Cadastros.Domain.Repositories;

public interface ICategoriaRepository
{
    Task<Categoria?> GetByIdAsync(int codcat, CancellationToken cancellationToken = default);
    Task<string?> ObterNomeEstruturaCompletaAsync(int codcat, CancellationToken cancellationToken = default);
}