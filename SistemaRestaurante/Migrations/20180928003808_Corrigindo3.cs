using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class Corrigindo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comandas_Pedido_PedidoId",
                table: "Comandas");

            migrationBuilder.DropIndex(
                name: "IX_Comandas_PedidoId",
                table: "Comandas");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Comandas");

            migrationBuilder.AddColumn<int>(
                name: "ComandaId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ComandaId",
                table: "Pedido",
                column: "ComandaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Comandas_ComandaId",
                table: "Pedido",
                column: "ComandaId",
                principalTable: "Comandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Comandas_ComandaId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ComandaId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Comandas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_PedidoId",
                table: "Comandas",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comandas_Pedido_PedidoId",
                table: "Comandas",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
