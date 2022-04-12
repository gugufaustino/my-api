using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Modelos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdSituacao",
                table: "Modelos",
                newName: "IdTipoSituacao");

            migrationBuilder.CreateTable(
                name: "TipoCasting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoCasting = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ModeloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCasting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoCasting_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoSituacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoSituacao = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSituacao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdTipoSituacao",
                table: "Modelos",
                column: "IdTipoSituacao");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCasting_ModeloId",
                table: "TipoCasting",
                column: "ModeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_TipoSituacao_IdTipoSituacao",
                table: "Modelos",
                column: "IdTipoSituacao",
                principalTable: "TipoSituacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_TipoSituacao_IdTipoSituacao",
                table: "Modelos");

            migrationBuilder.DropTable(
                name: "TipoCasting");

            migrationBuilder.DropTable(
                name: "TipoSituacao");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_IdTipoSituacao",
                table: "Modelos");

            migrationBuilder.RenameColumn(
                name: "IdTipoSituacao",
                table: "Modelos",
                newName: "IdSituacao");
        }
    }
}
