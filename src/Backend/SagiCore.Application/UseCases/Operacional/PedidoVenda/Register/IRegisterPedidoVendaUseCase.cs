using SagiCore.Communication.Requests.Operacional.PedidoVenda;
using SagiCore.Communication.Responses.Operacional.PedidoVenda;

namespace SagiCore.Application.UseCases.Operacional.PedidoVenda.Register
{
    public interface IRegisterPedidoVendaUseCase
    {
        public Task<ResponseRegisteredPedidoVendaJson> Execute(RequestRegisterPedidoVendaJson request);
    }
}
