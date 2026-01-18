using Microsoft.EntityFrameworkCore;
using SagiCore.Domain.Entities.Cadastro;
using SagiCore.Domain.Repositories.Cadastro.Produto;

namespace SagiCore.Infrastructure.DataAccess.Repositories.Cadastro
{
    public class ProdutoRepository : IProdutoWriteRepository, IProdutoReadRepository
    {
        private readonly SagiCoreDbContext _dbcontext;

        public ProdutoRepository(SagiCoreDbContext dbContext) => _dbcontext = dbContext;

        public async Task Add(Produto produto) => await _dbcontext.Produto.AddAsync(produto);

        public async Task<bool> ExisteProdutoComCodproRepetido(string codpro, string subcod)
        {
            return await _dbcontext.Produto.AnyAsync(p => p.codpro.Equals(codpro) && p.subcod.Equals(subcod));
            
        }
    }
}
