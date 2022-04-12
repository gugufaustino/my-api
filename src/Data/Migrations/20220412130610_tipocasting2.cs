using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class tipocasting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ModelosTipoCasting_IdTipoCasting",
                table: "ModelosTipoCasting",
                column: "IdTipoCasting");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelosTipoCasting_TipoCasting_IdTipoCasting",
                table: "ModelosTipoCasting",
                column: "IdTipoCasting",
                principalTable: "TipoCasting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelosTipoCasting_TipoCasting_IdTipoCasting",
                table: "ModelosTipoCasting");

            migrationBuilder.DropIndex(
                name: "IX_ModelosTipoCasting_IdTipoCasting",
                table: "ModelosTipoCasting");
        }
    }
}
