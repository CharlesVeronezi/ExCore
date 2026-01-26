using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SagiCore.Shared.Application.Tenancy;
using SagiCore.Shared.Application.User;
using SagiCore.Shared.Infrastructure.Tenancy;
using SagiCore.Shared.Infrastructure.User;

namespace SagiCore.Shared.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddMemoryCache();

            services.AddScoped<IUserContext, UserContext>();

            // TenantService: Resolve a string de conexão correta para o cliente atual
            services.AddScoped<ITenantService, TenantService>();

            return services;
        }
    }
}
