using SagiCore.Cadastros.Domain.Entities;
using SagiCore.Shared.Domain.Repositories;

namespace SagiCore.Cadastros.Domain.Repositories;

public interface IProdutoReadRepository : IReadRepository<Produto>
{
    Task<Produto?> GetByCodigoAsync(string codpro, string subcod, CancellationToken cancellationToken = default);
    Task<bool> ExisteComMesmoCodigo(string codpro, string subcod, CancellationToken cancellationToken = default);
}

public interface IProdutoWriteRepository : IWriteRepository<Produto>
{
}

public interface IProdutoRepository : IProdutoReadRepository, IProdutoWriteRepository
{
}
