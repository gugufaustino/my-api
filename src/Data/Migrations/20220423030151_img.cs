using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemPerfilNome",
                table: "Modelos",
                type: "varchar(250)",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemPerfilNome",
                table: "Modelos");
        }
    }
}
