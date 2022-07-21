using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class agencia_empresa_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AgenciasEmpresa_Cnpj",
                table: "AgenciasEmpresa",
                column: "Cnpj",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AgenciasEmpresa_Cnpj",
                table: "AgenciasEmpresa");
        }
    }
}
