using Microsoft.EntityFrameworkCore;
using SagiCore.Cadastros.Domain.Entities;
using SagiCore.Shared.Application.Tenancy;
using SagiCore.Shared.Infrastructure.Persistence;

namespace SagiCore.Cadastros.Infrastructure.Persistence
{
    public class CadastrosDbContext : BaseDbContext
    {
        private readonly ITenantService _tenantService;

        public CadastrosDbContext(DbContextOptions<CadastrosDbContext> options, ITenantService tenantService)
            : base(options)
        {
            _tenantService = tenantService;
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _tenantService.GetConnectionStringAsync().GetAwaiter().GetResult();

            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseNpgsql(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
