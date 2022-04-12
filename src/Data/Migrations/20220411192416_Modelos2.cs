using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Modelos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoCasting",
                table: "Modelos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoCasting",
                table: "Modelos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
