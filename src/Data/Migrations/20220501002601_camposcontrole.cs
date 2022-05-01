using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class camposcontrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioAtualizacao",
                table: "Modelos",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Modelos",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioAtualizacao",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Modelos");
        }
    }
}
