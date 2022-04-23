using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class imagemPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // custom
            migrationBuilder.UpdateData("Modelos", "ImagemPerfilNome", null, "ImagemPerfilNome", "");

            migrationBuilder.DropColumn(
                name: "FotoPerfilUrl",
                table: "Modelos");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemPerfilNome",
                table: "Modelos",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagemPerfilNome",
                table: "Modelos",
                type: "varchar(250)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false);

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfilUrl",
                table: "Modelos",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "");
        }
    }
}
