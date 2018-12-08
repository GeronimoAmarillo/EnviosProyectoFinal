using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class RelacionEntregaCadete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Cadete",
                table: "Entregas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CadetesCiEmpleado",
                table: "Entregas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_CadetesCiEmpleado",
                table: "Entregas",
                column: "CadetesCiEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Cadetes_CadetesCiEmpleado",
                table: "Entregas",
                column: "CadetesCiEmpleado",
                principalTable: "Cadetes",
                principalColumn: "CiEmpleado",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Cadetes_CadetesCiEmpleado",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_CadetesCiEmpleado",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "Cadete",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "CadetesCiEmpleado",
                table: "Entregas");
        }
    }
}
