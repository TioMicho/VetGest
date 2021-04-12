using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetGest.Migrations
{
    public partial class turnopeluqueria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurnoPeluquerias",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Lugar = table.Column<string>(type: "TEXT", nullable: true),
                    PacienteID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoPeluquerias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TurnoPeluquerias_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnoPeluquerias_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TurnoPeluquerias_ClienteID",
                table: "TurnoPeluquerias",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoPeluquerias_PacienteID",
                table: "TurnoPeluquerias",
                column: "PacienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnoPeluquerias");
        }
    }
}
