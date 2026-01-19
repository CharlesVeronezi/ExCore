using Microsoft.Extensions.DependencyInjection;
using SagiCore.Application.UseCases.Cadastro.Produto.Register;
using SagiCore.Application.UseCases.Operacional.PedidoVenda.Register;

namespace SagiCore.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterProdutoUseCase, RegisterProdutoUseCase>();
            services.AddScoped<IRegisterPedidoVendaUseCase, RegisterPedidoVendaUseCase>();
        }
    }
}
