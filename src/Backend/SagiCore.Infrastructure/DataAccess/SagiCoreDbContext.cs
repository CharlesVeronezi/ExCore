using Microsoft.EntityFrameworkCore;
using SagiCore.Domain.Entities;

namespace SagiCore.Infrastructure.DataAccess
{
    public class SagiCoreDbContext : DbContext
    {
        public SagiCoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("cag_pro");
                entity.HasKey(p => new { p.codpro, p.subcod });
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SagiCoreDbContext).Assembly);
        }
    }
}
