using Microsoft.EntityFrameworkCore;
using SagiCore.Cadastros.Domain.Entities;
using SagiCore.Shared.Infrastructure.Persistence;

namespace SagiCore.Cadastros.Infrastructure.Persistence
{
    public class CadastrosDbContext : BaseDbContext
    {
        public CadastrosDbContext(DbContextOptions<CadastrosDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastrosDbContext).Assembly);
        }
    }
}
