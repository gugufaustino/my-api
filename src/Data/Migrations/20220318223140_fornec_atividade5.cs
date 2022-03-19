using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fornec_atividade5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedores",
                type: "varchar(14)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Atividade",
                table: "Fornecedores",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedores",
                type: "varchar(11)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "Atividade",
                table: "Fornecedores",
                type: "varchar(200)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false);
        }
    }
}
