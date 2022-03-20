using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fornecedor_endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_IdEndereco",
                table: "Fornecedores",
                column: "IdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Endereco_IdEndereco",
                table: "Fornecedores",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Endereco_IdEndereco",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_IdEndereco",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Fornecedores");
        }
    }
}
