using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AgenciaEmpresa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "AgenciasEmpresa",
                type: "varchar(14)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "AgenciasEmpresa",
                type: "varchar(1)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false);
        }
    }
}
