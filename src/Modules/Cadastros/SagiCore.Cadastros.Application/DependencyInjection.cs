using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SagiCore.Shared.Application;
using System.Reflection;


namespace SagiCore.Cadastros.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCadastrosApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            services.AddModuleApplication(Assembly.GetExecutingAssembly());

            return services;
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            
            services.AddScoped<IMapper>(sp =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(Assembly.GetExecutingAssembly());
                });

                return config.CreateMapper();
            });
        }
    }
}
