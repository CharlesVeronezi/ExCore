using Microsoft.EntityFrameworkCore;
using SagiCore.Domain.Entities;
using SagiCore.Domain.Repositories;

namespace SagiCore.Infrastructure.DataAccess.Repositories
{
    public class ProdutoRepository : IProdutoWriteRepository, IProdutoReadRepository
    {
        private readonly SagiCoreDbContext _dbcontext;

        public ProdutoRepository(SagiCoreDbContext dbContext) => _dbcontext = dbContext;

        public async Task Add(Produto produto) => await _dbcontext.Produtos.AddAsync(produto);

        public async Task<bool> ExisteProdutoComCodproRepetido(string codpro, string subcod)
        {
            return await _dbcontext.Produtos.AnyAsync(p => p.codpro.Equals(codpro) && p.subcod.Equals(subcod));
            
        }
    }
}
