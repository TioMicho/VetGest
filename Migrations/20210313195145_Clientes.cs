using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VetGest.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Domicilio",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DueñoApellido",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DueñoNombre",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Pacientes");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteID",
                table: "Pacientes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    DueñoNombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DueñoApellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Domicilio = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Pacientes");

            migrationBuilder.AddColumn<string>(
                name: "Domicilio",
                table: "Pacientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DueñoApellido",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DueñoNombre",
                table: "Pacientes",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Pacientes",
                type: "INTEGER",
                nullable: true);
        }
    }
}
