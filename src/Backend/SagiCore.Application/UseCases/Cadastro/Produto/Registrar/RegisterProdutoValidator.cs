using FluentValidation;
using SagiCore.Communication.Requests;
using SagiCore.Exceptions;

namespace SagiCore.Application.UseCases.Cadastro.Produto.Registrar
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
