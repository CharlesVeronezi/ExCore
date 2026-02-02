using FluentValidation;
using SagiCore.Cadastros.Domain.Repositories;
using SagiCore.Exceptions;

namespace SagiCore.Cadastros.Application.Produtos.Register;

public class RegisterProdutoValidator : AbstractValidator<RegisterProdutoCommand>
{
    public RegisterProdutoValidator(
        ICategoriaRepository categoriaRepository,
        IUnidadeRepository unidadeRepository)
    {
        // Validações síncronas de formato/tamanho
        RuleFor(x => x.Produto)
            .NotEmpty()
            .WithMessage(ResourceMessagesException.PRODUTO_EMPTY)
            .MaximumLength(60)
            .WithMessage("Descrição não pode ter mais de 60 caracteres");

        RuleFor(x => x.Unidade)
            .NotEmpty()
            .WithMessage(ResourceMessagesException.UNIT_NOT_FOUND)
            .MinimumLength(2)
            .MaximumLength(3)
            .WithMessage(ResourceMessagesException.UNIT_SIZE_INVALID);

        RuleFor(x => x.Ncm)
            .NotEmpty()
            .Length(8)
            .WithMessage(ResourceMessagesException.NCM_SIZE_INVALID);

        RuleFor(x => x.TipoProduto)
            .NotEmpty()
            .MaximumLength(2);

        RuleFor(x => x.CodigoCategoria)
            .GreaterThan(0)
            .WithMessage(ResourceMessagesException.CATEGORY_NOT_FOUND);

        // Validações assíncronas de dependência
        RuleFor(x => x.CodigoCategoria)
            .MustAsync(async (codcat, ct) => 
                await categoriaRepository.GetByIdAsync(codcat, ct) is not null)
            .WithMessage(ResourceMessagesException.CATEGORY_NOT_FOUND);

        RuleFor(x => x.Unidade)
            .MustAsync(async (unidade, ct) => 
                await unidadeRepository.ExisteAsync(unidade, ct))
            .WithMessage(ResourceMessagesException.UNIT_NOT_FOUND);
    }
}
