using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fornec_atividade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedores",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false);

            migrationBuilder.AddColumn<string>(
                name: "Atividade",
                table: "Fornecedores",
                type: "varchar(1)",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atividade",
                table: "Fornecedores");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedores",
                type: "varchar(14)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false);
        }
    }
}
