using GCS.ERP.Core.Classes;
using GCS.ERP.Core.VO;
using GCSERP.Produtos.Entidades.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCSERP.Produtos.Dados.Mapeamentos
{
    public class MapeamentoProduto : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(2500)");

            builder.Property(c => c.CodigoExterno)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Marca)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.UnidadeMedidaClassificacao)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.OwnsOne(c => c.UnidadeMedidaEstoque,
                tf =>
                {
                    tf.Property(c => c.Valor)
                        .HasColumnName("NCM")
                        .IsRequired();
                }
            );                

            builder.OwnsOne(c => c.NCM,
                tf =>
                {
                    tf.Property(c => c.Valor)
                        .HasColumnName("UnidadeMedidaEstoque")
                        .HasColumnType($"varchar({GCSERPNCM.TAMANHO})");
                });

            builder.Property(c => c.Observacoes)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.HasOne(c => c.Clasificacao)
                .WithMany(p => p.Produtos);


            MapeamentoCamposPadrao.MapearCamposPadraoBD(builder);
            MapeamentoCamposPadrao.CamposPadraoBDCadastro(builder);


            builder.ToTable("CadProdutos");
        }
    }
}
