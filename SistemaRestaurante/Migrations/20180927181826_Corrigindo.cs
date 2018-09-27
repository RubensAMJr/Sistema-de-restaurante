using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class Corrigindo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);
        }
    }
}
