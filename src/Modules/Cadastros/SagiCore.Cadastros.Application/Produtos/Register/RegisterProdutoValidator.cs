using FluentValidation;
using SagiCore.Exceptions;

namespace SagiCore.Cadastros.Application.Produtos.Register
{
    public class RegisterProdutoValidator : AbstractValidator<RegisterProdutoCommand>
    {
        public RegisterProdutoValidator()
        {
            RuleFor(x => x.Codpro)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.CODPRO_EMPTY);

            RuleFor(x => x.Subcod)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.SUBCOD_EMPTY);

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage(ResourceMessagesException.PRODUTO_EMPTY)
                .MaximumLength(60)
                .WithMessage("Descrição não pode ter mais de 60 caracteres");

            RuleFor(x => x.Unidade)
                .NotEmpty()
                .MaximumLength(3);
        }
    }
}
