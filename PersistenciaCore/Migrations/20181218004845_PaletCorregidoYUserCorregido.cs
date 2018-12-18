using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class PaletCorregidoYUserCorregido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuarios",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Palets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaIngreso",
                table: "Palets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaSalida",
                table: "Palets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Palets");

            migrationBuilder.DropColumn(
                name: "fechaIngreso",
                table: "Palets");

            migrationBuilder.DropColumn(
                name: "fechaSalida",
                table: "Palets");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuarios",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
