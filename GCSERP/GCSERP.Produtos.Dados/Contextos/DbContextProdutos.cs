using GCS.ERP.Core.Interfaces;
using GCSERP.Produtos.Entidades.Classes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GCSERP.Produtos.Dados.Contextos
{
    public class DbContextProdutos : DbContext, IGCSUnityOfWork
    {
        public DbContextProdutos(DbContextOptions<DbContextProdutos> options) 
            : base(options)
        {
        }

        public DbSet<ProdutoClassificacao> ClassificacoesProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public async Task<bool> CommitAsync()
            => await base.SaveChangesAsync() > 0;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextProdutos).Assembly);
        }
    }
}
