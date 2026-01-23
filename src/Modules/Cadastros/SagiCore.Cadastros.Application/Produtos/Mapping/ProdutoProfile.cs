using AutoMapper;
using SagiCore.Cadastros.Domain.Entities;
using SagiCore.Communication.Requests.Cadastro.Produto;
using SagiCore.Communication.Responses.Cadastro.Produto;

namespace SagiCore.Cadastros.Application.Produtos.Mapping
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            // Mapping de Request → Entidade
            CreateMap<RequestRegisterProdutoJson, Produto>();

            // Mapping de Entidade → Response
            CreateMap<Produto, ResponseRegisteredProdutoJson>();
        }
    }
}
