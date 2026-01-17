using SagiCore.Communication.Requests;
using SagiCore.Communication.Responses;

namespace SagiCore.Application.UseCases.Produto.Registrar
{
    public interface IRegistrarProdutoUseCase
    {
        public Task<ResponseRegisteredProdutoJson> Executar(RequestRegisterProdutoJson request);
    }
}
