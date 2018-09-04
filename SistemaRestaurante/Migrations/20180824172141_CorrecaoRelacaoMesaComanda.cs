using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class CorrecaoRelacaoMesaComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Mesas_MesaId",
                table: "Comandas");

            migrationBuilder.AlterColumn<int>(
                name: "MesaId",
                table: "Comandas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Mesas_MesaId",
                table: "Comandas",
                column: "MesaId",
                principalTable: "Mesas",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Mesas_MesaId",
                table: "Comandas");

            migrationBuilder.AlterColumn<int>(
                name: "MesaId",
                table: "Comandas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Mesas_MesaId",
                table: "Comandas",
                column: "MesaId",
                principalTable: "Mesas",
                principalColumn: "MesaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
