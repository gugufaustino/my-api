using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Modelos4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeTipoSituacao",
                table: "TipoSituacao",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTipoCasting",
                table: "TipoCasting",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeTipoSituacao",
                table: "TipoSituacao",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "NomeTipoCasting",
                table: "TipoCasting",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false);
        }
    }
}
