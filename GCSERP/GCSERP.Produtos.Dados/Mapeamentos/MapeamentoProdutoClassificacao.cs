using GCSERP.Produtos.Entidades.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCSERP.Produtos.Dados.Mapeamentos
{
    public class MapeamentoProdutoClassificacao : IEntityTypeConfiguration<ProdutoClassificacao>
    {
        public void Configure(EntityTypeBuilder<ProdutoClassificacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasMany(p => p.Produtos)
                .WithOne(c => c.Clasificacao);

            MapeamentoCamposPadrao.MapearCamposPadraoBD(builder);
            MapeamentoCamposPadrao.CamposPadraoBDCadastro(builder);

            builder.ToTable("CadProdutosClassificacoes");
        }
    }
}
