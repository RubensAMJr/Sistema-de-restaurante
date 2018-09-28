using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class Corrigindo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Comandas_ComandaId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ComandaId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ComandaId",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "ItensPedido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ComandaId",
                table: "Pedido",
                column: "ComandaId",
                unique: true,
                filter: "[ComandaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Comandas_ComandaId",
                table: "Pedido",
                column: "ComandaId",
                principalTable: "Comandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "Data",
                table: "ItensPedido");

            migrationBuilder.AlterColumn<int>(
                name: "ComandaId",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Pedido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
