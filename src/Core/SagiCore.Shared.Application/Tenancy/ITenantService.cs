namespace SagiCore.Shared.Application.Tenancy
{
    public interface ITenantService
    {
        Task<string> GetConnectionStringAsync();
    }
}
