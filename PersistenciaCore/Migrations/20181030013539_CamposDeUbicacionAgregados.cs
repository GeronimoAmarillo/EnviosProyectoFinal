using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class CamposDeUbicacionAgregados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "IdTelefono",
                table: "Cadetes");

            migrationBuilder.AlterColumn<long>(
                name: "RUT",
                table: "Ingresos",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "Cadetes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "Cadetes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Cadetes");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Cadetes");

            migrationBuilder.AlterColumn<long>(
                name: "RUT",
                table: "Ingresos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdTelefono",
                table: "Cadetes",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
