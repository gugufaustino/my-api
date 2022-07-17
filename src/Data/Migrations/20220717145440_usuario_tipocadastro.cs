using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class usuario_tipocadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoCadastro",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoCadastro",
                table: "Usuarios");
        }
    }
}
