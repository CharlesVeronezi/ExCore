using SagiCore.Domain.Entities.Operacional;

namespace SagiCore.Domain.Repositories.Operacional.PedidoVenda
{
    public interface IPedidoVendaWriteRepository
    {
        public Task Add(Entities.Operacional.PedidoVenda pedidoVenda);
    }
}
