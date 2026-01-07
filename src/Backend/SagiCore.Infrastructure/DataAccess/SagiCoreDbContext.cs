using Microsoft.EntityFrameworkCore;
using SagiCore.Domain.Entities;

namespace SagiCore.Infrastructure.DataAccess
{
    public class SagiCoreDbContext : DbContext
    {
        public SagiCoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SagiCoreDbContext).Assembly);
        }
    }
}
