using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDePessoa.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Salario = table.Column<double>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_DepartamentoId",
                table: "Colaborador",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");
        }
    }
}
