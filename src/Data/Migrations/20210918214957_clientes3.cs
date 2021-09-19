using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class clientes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientees",
                table: "Clientees");

            migrationBuilder.RenameTable(
                name: "Clientees",
                newName: "Clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Clientees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientees",
                table: "Clientees",
                column: "Id");
        }
    }
}
