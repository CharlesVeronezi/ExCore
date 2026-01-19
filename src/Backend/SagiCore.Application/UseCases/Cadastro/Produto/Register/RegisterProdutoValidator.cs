using FluentValidation;
using SagiCore.Communication.Requests.Cadastro.Produto;
using SagiCore.Exceptions;

namespace SagiCore.Application.UseCases.Cadastro.Produto.Register
{
    public class RegisterProdutoValidator : AbstractValidator<RequestRegisterProdutoJson>
    {
        public RegisterProdutoValidator() 
        {
            RuleFor(produto => produto.codpro).NotEmpty().WithMessage(ResourceMessagesException.CODPRO_EMPTY); 
            RuleFor(produto => produto.subcod).NotEmpty().WithMessage(ResourceMessagesException.SUBCOD_EMPTY);
            RuleFor(produto => produto.produto).NotEmpty().WithMessage(ResourceMessagesException.PRODUTO_EMPTY);
        }
    }
}
