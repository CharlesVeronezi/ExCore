using SagiCore.Communication.Requests;
using SagiCore.Communication.Responses;

namespace SagiCore.Application.UseCases.Cadastro.Produto.Registrar
{
    public interface IRegisterProdutoUseCase
    {
        public Task<ResponseRegisteredProdutoJson> Executar(RequestRegisterProdutoJson request);
    }
}
