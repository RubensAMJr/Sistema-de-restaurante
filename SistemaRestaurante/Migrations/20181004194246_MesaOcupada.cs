using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class MesaOcupada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ocupada",
                table: "Mesas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocupada",
                table: "Mesas");
        }
    }
}
