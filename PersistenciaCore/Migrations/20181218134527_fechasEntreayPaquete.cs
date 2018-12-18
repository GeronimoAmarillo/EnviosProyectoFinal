using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class fechasEntreayPaquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSalida",
                table: "Paquetes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Entregas",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSalida",
                table: "Paquetes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Entregas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
