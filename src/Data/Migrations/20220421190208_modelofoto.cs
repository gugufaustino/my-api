using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modelofoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPerfilUrl",
                table: "Modelos",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfilUrl",
                table: "Modelos");
        }
    }
}
