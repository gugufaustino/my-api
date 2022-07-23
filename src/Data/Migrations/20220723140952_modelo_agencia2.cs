using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modelo_agencia2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdAgencia",
                table: "Modelos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdAgencia",
                table: "Modelos",
                column: "IdAgencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Agencias_IdAgencia",
                table: "Modelos",
                column: "IdAgencia",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Agencias_IdAgencia",
                table: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_IdAgencia",
                table: "Modelos");

            migrationBuilder.AlterColumn<int>(
                name: "IdAgencia",
                table: "Modelos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
