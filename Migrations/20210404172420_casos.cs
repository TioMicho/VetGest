using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetGest.Migrations
{
    public partial class casos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllazgosClinicos",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "EstadoCorporal",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "FrecuenciaCardiaca",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "FrecuenciaRespiratoria",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "Hidratacion",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "RecomendacionesMedicacion",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "Casos");

            migrationBuilder.DropColumn(
                name: "TiempoLlenadoCapilar",
                table: "Casos");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Casos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Revisiones",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CasoID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: true),
                    Temperatura = table.Column<double>(type: "REAL", nullable: true),
                    EstadoCorporal = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoLlenadoCapilar = table.Column<string>(type: "TEXT", nullable: true),
                    Hidratacion = table.Column<string>(type: "TEXT", nullable: true),
                    FrecuenciaRespiratoria = table.Column<string>(type: "TEXT", nullable: true),
                    FrecuenciaCardiaca = table.Column<string>(type: "TEXT", nullable: true),
                    AllazgosClinicos = table.Column<string>(type: "TEXT", nullable: true),
                    RecomendacionesMedicacion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaProximaCita = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisiones", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revisiones");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Casos");

            migrationBuilder.AddColumn<string>(
                name: "AllazgosClinicos",
                table: "Casos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoCorporal",
                table: "Casos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrecuenciaCardiaca",
                table: "Casos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrecuenciaRespiratoria",
                table: "Casos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hidratacion",
                table: "Casos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Casos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecomendacionesMedicacion",
                table: "Casos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Temperatura",
                table: "Casos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TiempoLlenadoCapilar",
                table: "Casos",
                type: "TEXT",
                nullable: true);
        }
    }
}
