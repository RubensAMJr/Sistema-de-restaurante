using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class QuantidadeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numeroVendas",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numeroVendas",
                table: "Produtos");
        }
    }
}
