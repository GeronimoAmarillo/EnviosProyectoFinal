using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class CorrigiendoReclamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamo_Paquetes_Paquete",
                table: "Reclamo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamo_Paquetes_Paquete",
                table: "Reclamo",
                column: "Paquete",
                principalTable: "Paquetes",
                principalColumn: "NumReferencia",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamo_Paquetes_Paquete",
                table: "Reclamo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamo_Paquetes_Paquete",
                table: "Reclamo",
                column: "Paquete",
                principalTable: "Paquetes",
                principalColumn: "NumReferencia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
