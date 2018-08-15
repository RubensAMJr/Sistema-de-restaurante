using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Comandas",
                newName: "Numero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Comandas",
                newName: "Nome");
        }
    }
}
