using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class SoluciondeCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Clientes_RUT",
                table: "Ingresos");

            migrationBuilder.AlterColumn<long>(
                name: "RUT",
                table: "Ingresos",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Clientes_RUT",
                table: "Ingresos",
                column: "RUT",
                principalTable: "Clientes",
                principalColumn: "RUT",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Clientes_RUT",
                table: "Ingresos");

            migrationBuilder.AlterColumn<long>(
                name: "RUT",
                table: "Ingresos",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Clientes_RUT",
                table: "Ingresos",
                column: "RUT",
                principalTable: "Clientes",
                principalColumn: "RUT",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
