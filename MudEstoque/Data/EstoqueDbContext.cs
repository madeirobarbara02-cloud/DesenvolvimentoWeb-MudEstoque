using Microsoft.EntityFrameworkCore;
using MudEstoque.Models;

namespace MudEstoque.Data
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<MovimentacaoEstoque> Movimentacoes { get; set; }
        // Descreve o que as Data Annotations não alcançam: 1:1 e exclusões
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var produto = modelBuilder.Entity<Produto>();

            // Produto 1:1 Estoque, com cascata (igual ao script)
            produto.HasOne(p => p.Estoque).WithOne(e => e.Produto)
                   .HasForeignKey<Estoque>(e => e.ProdutoId)
                   .OnDelete(DeleteBehavior.Cascade);

            // No banco estas FKs não têm cascata
            produto.HasOne(p => p.Categoria).WithMany(c => c.Produtos)
                   .OnDelete(DeleteBehavior.Restrict);
            produto.HasOne(p => p.Fornecedor).WithMany(f => f.Produtos)
                   .OnDelete(DeleteBehavior.Restrict);
            produto.HasMany(p => p.Movimentacoes).WithOne(m => m.Produto)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
