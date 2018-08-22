using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaRestaurante.Migrations
{
    public partial class MesaComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MesaId",
                table: "Comandas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comandas",
                newName: "ComandaId");

            migrationBuilder.CreateTable(
                name: "MesasComandas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComandaId = table.Column<int>(nullable: false),
                    MesaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesasComandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MesasComandas_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MesasComandas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MesasComandas_ComandaId",
                table: "MesasComandas",
                column: "ComandaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MesasComandas_MesaId",
                table: "MesasComandas",
                column: "MesaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MesasComandas");

            migrationBuilder.RenameColumn(
                name: "ComandaId",
                table: "Comandas",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "MesaId",
                table: "Comandas",
                nullable: false,
                defaultValue: 0);
        }
    }
}
