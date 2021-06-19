using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDePessoa.Migrations
{
    public partial class DepartamentosForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Departamentos_DepartamentoId",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_DepartamentoId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Colaborador");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentosId",
                table: "Colaborador",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_DepartamentosId",
                table: "Colaborador",
                column: "DepartamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Departamentos_DepartamentosId",
                table: "Colaborador",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Departamentos_DepartamentosId",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_DepartamentosId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "DepartamentosId",
                table: "Colaborador");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Colaborador",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_DepartamentoId",
                table: "Colaborador",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Departamentos_DepartamentoId",
                table: "Colaborador",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
