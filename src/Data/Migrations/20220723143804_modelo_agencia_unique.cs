using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modelo_agencia_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Modelos_CPF_IdAgencia",
                table: "Modelos",
                columns: new[] { "CPF", "IdAgencia" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Modelos_CPF_IdAgencia",
                table: "Modelos");
        }
    }
}
