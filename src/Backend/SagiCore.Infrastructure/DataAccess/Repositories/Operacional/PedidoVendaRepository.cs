using Microsoft.EntityFrameworkCore;
using SagiCore.Domain.Entities.Operacional;
using SagiCore.Domain.Repositories.Operacional.PedidoVenda;

namespace SagiCore.Infrastructure.DataAccess.Repositories.Operacional
{
    public class PedidoVendaRepository : IPedidoVendaWriteRepository, IPedidoVendaReadRepository
    {
        private readonly SagiCoreDbContext _dbcontext;

        public PedidoVendaRepository(SagiCoreDbContext dbContext) => _dbcontext = dbContext;

        public async Task Add(Domain.Entities.Operacional.PedidoVenda pedidoVenda)
        {
            await _dbcontext.PedidoVenda.AddAsync(pedidoVenda);
        }
    }
}