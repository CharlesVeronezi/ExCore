using SagiCore.Communication.Requests.Cadastro.Produto;
using SagiCore.Communication.Responses.Cadastro.Produto;

namespace SagiCore.Application.UseCases.Cadastro.Produto.Register
{
    public interface IRegisterProdutoUseCase
    {
        public Task<ResponseRegisteredProdutoJson> Execute(RequestRegisterProdutoJson request);
    }
}
