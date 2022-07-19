using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class agencia3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Agencias",
                type: "varchar(250)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Agencias",
                type: "varchar(250)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
