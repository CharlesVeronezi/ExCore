using Microsoft.Extensions.DependencyInjection;
using SagiCore.Application.UseCases.Produto.Registrar;

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
            services.AddScoped<IRegistrarProdutoUseCase, RegistrarProdutoUseCase>();
        }
    }
}
