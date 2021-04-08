using Microsoft.EntityFrameworkCore.Migrations;

namespace VetGest.Migrations
{
    public partial class revisiones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Revisiones",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_CasoID",
                table: "Revisiones",
                column: "CasoID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSanitarios_PacienteID",
                table: "PlanSanitarios",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ClienteID",
                table: "Pacientes",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_PacienteID",
                table: "Casos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_UsuarioId",
                table: "Casos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casos_AspNetUsers_UsuarioId",
                table: "Casos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Casos_Pacientes_PacienteID",
                table: "Casos",
                column: "PacienteID",
                principalTable: "Pacientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Cliente_ClienteID",
                table: "Pacientes",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanSanitarios_Pacientes_PacienteID",
                table: "PlanSanitarios",
                column: "PacienteID",
                principalTable: "Pacientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revisiones_Casos_CasoID",
                table: "Revisiones",
                column: "CasoID",
                principalTable: "Casos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casos_AspNetUsers_UsuarioId",
                table: "Casos");

            migrationBuilder.DropForeignKey(
                name: "FK_Casos_Pacientes_PacienteID",
                table: "Casos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Cliente_ClienteID",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanSanitarios_Pacientes_PacienteID",
                table: "PlanSanitarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Revisiones_Casos_CasoID",
                table: "Revisiones");

            migrationBuilder.DropIndex(
                name: "IX_Revisiones_CasoID",
                table: "Revisiones");

            migrationBuilder.DropIndex(
                name: "IX_PlanSanitarios_PacienteID",
                table: "PlanSanitarios");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ClienteID",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Casos_PacienteID",
                table: "Casos");

            migrationBuilder.DropIndex(
                name: "IX_Casos_UsuarioId",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Revisiones");
        }
    }
}
