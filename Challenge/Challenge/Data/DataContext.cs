using Microsoft.EntityFrameworkCore;
using Challenge.Models;

namespace Challenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ItensPedido> ItensPedidos { get; set; } 
        public DbSet<Pedido> Pedidos { get; set; } 
        public DbSet<Produto> Produtos { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<ItensPedido>(entity =>
            {
                entity.ToTable("ItensPedido");
                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.ItensPedidos)
                    .HasForeignKey(d => d.PedidoId)
                    .HasConstraintName("FK_Pedido");
                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ItensPedidos)
                    .HasForeignKey(d => d.ProdutoId)
                    .HasConstraintName("FK_produto");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");
                entity.Property(e => e.DataCriacao).HasColumnType("datetime");
                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto");
                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            });
        }
    }
}
