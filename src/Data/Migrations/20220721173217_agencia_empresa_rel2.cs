using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class agencia_empresa_rel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencias_AgenciasEmpresa_IdEmpresa",
                table: "Agencias");

            migrationBuilder.DropIndex(
                name: "IX_Agencias_IdEmpresa",
                table: "Agencias");

            migrationBuilder.DropColumn(
                name: "IdEmpresa",
                table: "Agencias");

            migrationBuilder.AddForeignKey(
                name: "FK_AgenciasEmpresa_Agencias_Id",
                table: "AgenciasEmpresa",
                column: "Id",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgenciasEmpresa_Agencias_Id",
                table: "AgenciasEmpresa");

            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa",
                table: "Agencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_IdEmpresa",
                table: "Agencias",
                column: "IdEmpresa",
                unique: true,
                filter: "[IdEmpresa] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencias_AgenciasEmpresa_IdEmpresa",
                table: "Agencias",
                column: "IdEmpresa",
                principalTable: "AgenciasEmpresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
