using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCSERP.MVC.Migrations
{
    public partial class Produtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadProdutosClassificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Apagado = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRemocao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Historico = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    CodigoExterno = table.Column<string>(type: "varchar(100)", nullable: true),
                    VersaoInterna = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadProdutosClassificacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CadProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(2500)", nullable: true),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: true),
                    UnidadeMedidaClassificacao = table.Column<byte>(type: "tinyint", nullable: false),
                    NCM = table.Column<short>(type: "smallint", nullable: true),
                    UnidadeMedidaEstoque = table.Column<string>(type: "varchar(8)", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    ProdutoClassificacaoId = table.Column<int>(type: "int", nullable: false),
                    Apagado = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false, defaultValue: "N"),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRemocao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Historico = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    CodigoExterno = table.Column<string>(type: "varchar(100)", nullable: true),
                    VersaoInterna = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CadProdutos_CadProdutosClassificacoes_ProdutoClassificacaoId",
                        column: x => x.ProdutoClassificacaoId,
                        principalTable: "CadProdutosClassificacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadProdutos_ProdutoClassificacaoId",
                table: "CadProdutos",
                column: "ProdutoClassificacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadProdutos");

            migrationBuilder.DropTable(
                name: "CadProdutosClassificacoes");
        }
    }
}
