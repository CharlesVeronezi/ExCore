using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SagiCore.Shared.Application.Behaviors;
using System.Reflection;


namespace SagiCore.Shared.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedApplication(this IServiceCollection services)
        {
            // Registra o ValidationBehavior para todas as requests
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }

        public static IServiceCollection AddModuleApplication(this IServiceCollection services, Assembly assembly)
        {
            // Registra MediatR handlers do módulo
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            // Registra Validators do módulo
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}