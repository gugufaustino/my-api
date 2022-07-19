using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class agenciaEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoSituacao",
                table: "Agencias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoSituacao",
                table: "Agencias");
        }
    }
}
