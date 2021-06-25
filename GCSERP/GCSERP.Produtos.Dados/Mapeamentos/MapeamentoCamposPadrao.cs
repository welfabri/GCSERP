using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCSERP.Produtos.Dados.Mapeamentos
{
    public static class MapeamentoCamposPadrao
    {
        public static void MapearCamposPadraoBD(EntityTypeBuilder builder)
        {
            builder.Property("CodigoExterno")
                .HasColumnType("varchar(100)");

            builder.Property("VersaoInterna")
                .HasDefaultValue(1);
        }

        public static void CamposPadraoBDCadastro(EntityTypeBuilder builder)
        {
            builder.Property("Apagado")
                .HasColumnType("char(1)")
                .HasMaxLength(1)
                .IsRequired()
                .HasDefaultValue("N");

            builder.Property("DataInsercao")
                .IsRequired();

            builder.Property("DataAtualizacao");

            builder.Property("DataRemocao");

            builder.Property("Historico")
                .HasColumnType("varchar(MAX)");

            builder.Ignore("IdInterno");
        }
    }
}
