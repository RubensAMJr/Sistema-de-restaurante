using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class ItemPedido2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Produtos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Pedido",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemPedidoId",
                table: "ItensPedido",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ComandaId",
                table: "Comandas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CartaoId",
                table: "Cartoes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produtos",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pedido",
                newName: "PedidoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItensPedido",
                newName: "ItemPedidoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comandas",
                newName: "ComandaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cartoes",
                newName: "CartaoId");
        }
    }
}
