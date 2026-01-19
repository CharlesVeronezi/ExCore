using SagiCore.Exceptions;
using SagiCore.Communication.Requests.Operacional.PedidoVenda;
using FluentValidation;

namespace SagiCore.Application.UseCases.Operacional.PedidoVenda.Register
{
    public class RegisterPedidoVendaValidator : AbstractValidator<RequestRegisterPedidoVendaJson>
    {
        public RegisterPedidoVendaValidator()
        {
            RuleFor(pedido => pedido.pednum).GreaterThan(0).WithMessage("Criar no resource");
            RuleFor(pedido => pedido.codcli).GreaterThan(0).WithMessage("Criar no resource");
            RuleFor(pedido => pedido.itens).NotEmpty().WithMessage("Criar no resource");
        }
    }
}
