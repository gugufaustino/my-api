using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Agencia_AgenciaEmpresa_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAgencia",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AgenciasEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(500)", unicode: false, nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(1)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenciasEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAgencia = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    Instagram = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    TipoCadastro = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencias_AgenciasEmpresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "AgenciasEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdAgencia",
                table: "Usuarios",
                column: "IdAgencia");

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_IdEmpresa",
                table: "Agencias",
                column: "IdEmpresa",
                unique: true,
                filter: "[IdEmpresa] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Agencias_IdAgencia",
                table: "Usuarios",
                column: "IdAgencia",
                principalTable: "Agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Agencias_IdAgencia",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "AgenciasEmpresa");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdAgencia",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdAgencia",
                table: "Usuarios");
        }
    }
}
