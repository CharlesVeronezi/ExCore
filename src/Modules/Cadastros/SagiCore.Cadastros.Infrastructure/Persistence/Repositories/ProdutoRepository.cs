using Microsoft.EntityFrameworkCore;
using SagiCore.Cadastros.Domain.Entities;
using SagiCore.Cadastros.Domain.Repositories;
using SagiCore.Shared.Infrastructure.Persistence;

namespace SagiCore.Cadastros.Infrastructure.Persistence.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto, CadastrosDbContext>, IProdutoRepository
    {
        public ProdutoRepository(CadastrosDbContext context) : base(context)
        {
        }

        public async Task<Produto?> GetByCodigoAsync(string codpro, string subcod, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.codpro == codpro && p.subcod == subcod, cancellationToken);
        }

        public async Task<bool> ExisteComMesmoCodigo(string codpro, string subcod, CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(p => p.codpro == codpro && p.subcod == subcod, cancellationToken);
        }
    }
}
