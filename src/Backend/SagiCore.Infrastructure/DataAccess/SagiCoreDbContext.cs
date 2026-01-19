using Microsoft.EntityFrameworkCore;
using SagiCore.Domain.Entities.Cadastro;
using SagiCore.Domain.Entities.Operacional;

namespace SagiCore.Infrastructure.DataAccess
{
    public class SagiCoreDbContext : DbContext
    {
        public SagiCoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<PedidoVenda> PedidoVenda { get; set; }
        public DbSet<PedidoVendaItem> PedidoVendaItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("cag_pro");
                entity.HasKey(p => new { p.codpro, p.subcod });
            });

            modelBuilder.Entity<PedidoVenda>(entity =>
            {
                entity.ToTable("pedido_ven");
                entity.HasKey(p => p.pednum);
                entity.HasMany(p => p.Itens)
                      .WithOne(i => i.PedidoVenda)
                      .HasForeignKey(i => i.pednum);
            });

            modelBuilder.Entity<PedidoVendaItem>(entity =>
            {
                entity.ToTable("pediten_v");
                entity.HasKey(i => new { i.pednum, i.codpro, i.subcod });
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SagiCoreDbContext).Assembly);
        }
    }
}
