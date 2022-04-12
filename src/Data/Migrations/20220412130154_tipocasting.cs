using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class tipocasting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoCasting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomeTipoCasting = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCasting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoCasting");
        }
    }
}
