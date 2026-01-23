using Microsoft.Extensions.DependencyInjection;
using SagiCore.Shared.Application;
using System.Reflection;

namespace SagiCore.Cadastros.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCadastrosApplication(this IServiceCollection services)
        {
            services.AddModuleApplication(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
