using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Modelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Rg = table.Column<string>(type: "varchar(50)", unicode: false, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", unicode: false, nullable: false),
                    Diponibilidade = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    TipoCasting = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", unicode: false, nullable: false),
                    Instagram = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    Facebook = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    Linkedin = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Manequim = table.Column<int>(type: "int", nullable: false),
                    Sapato = table.Column<int>(type: "int", nullable: false),
                    CorOlhos = table.Column<int>(type: "int", nullable: false),
                    CorCabelo = table.Column<int>(type: "int", nullable: false),
                    TipoCabelo = table.Column<int>(type: "int", nullable: false),
                    TipoCabeloComprimento = table.Column<int>(type: "int", nullable: false),
                    IdSituacao = table.Column<int>(type: "int", nullable: false),
                    DthInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DthAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdEndereco",
                table: "Modelos",
                column: "IdEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");
        }
    }
}
