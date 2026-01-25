using AutoMapper;
using SagiCore.Cadastros.Application.Produtos.Register;
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

            //Command->Entidade
            CreateMap<RegisterProdutoCommand, Produto>()
                // Mapeamentos manuais para campos com nomes diferentes
                .ForMember(dest => dest.un, opt => opt.MapFrom(src => src.Unidade))
                .ForMember(dest => dest.codcat, opt => opt.MapFrom(src => src.CodigoCategoria))
                .ForMember(dest => dest.tp_prod, opt => opt.MapFrom(src => src.TipoProduto))
                .ForMember(dest => dest.codref1, opt => opt.MapFrom(src => src.CodigoReferencia1))
                .ForMember(dest => dest.codref2, opt => opt.MapFrom(src => src.CodigoReferencia2));

            // Mapping de Entidade → Response
            CreateMap<Produto, ResponseRegisteredProdutoJson>();
        }
    }
}
