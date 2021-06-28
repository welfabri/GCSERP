using Microsoft.EntityFrameworkCore.Migrations;

namespace GCSERP.MVC.Migrations
{
    public partial class SegundaAlteracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "CadProdutosClassificacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "CadProdutos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "CadProdutosClassificacoes");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "CadProdutos");
        }
    }
}
