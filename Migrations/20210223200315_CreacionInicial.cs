using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetGest.Migrations
{
    public partial class CreacionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MotivoConsulta = table.Column<string>(type: "TEXT", nullable: true),
                    Peso = table.Column<int>(type: "INTEGER", nullable: true),
                    Temperatura = table.Column<int>(type: "INTEGER", nullable: true),
                    EstadoCorporal = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoLlenadoCapilar = table.Column<string>(type: "TEXT", nullable: true),
                    Hidratacion = table.Column<string>(type: "TEXT", nullable: true),
                    FrecuenciaRespiratoria = table.Column<string>(type: "TEXT", nullable: true),
                    FrecuenciaCardiaca = table.Column<string>(type: "TEXT", nullable: true),
                    AllazgosClinicos = table.Column<string>(type: "TEXT", nullable: true),
                    RecomendacionesMedicacion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DueñoNombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DueñoApellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Domicilio = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<int>(type: "INTEGER", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Raza = table.Column<string>(type: "TEXT", nullable: true),
                    Especie = table.Column<string>(type: "TEXT", nullable: true),
                    Pelaje = table.Column<string>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", nullable: true),
                    Chip = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanSanitarios",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VacunaAntiparasitario = table.Column<string>(type: "TEXT", nullable: true),
                    FechaRefuerzo = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSanitarios", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "PlanSanitarios");
        }
    }
}
