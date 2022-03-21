using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ignorePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Usuarios",
                type: "varchar(100)",
                unicode: false,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "varchar(100)",
                unicode: false,
                nullable: false,
                defaultValue: "");
        }
    }
}
