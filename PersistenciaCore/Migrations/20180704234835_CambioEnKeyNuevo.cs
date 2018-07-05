using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class CambioEnKeyNuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Empleados_Ci",
                table: "Administradores");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_Ci",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "Ci",
                table: "Administradores");

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Empleados_CiEmpleado",
                table: "Administradores",
                column: "CiEmpleado",
                principalTable: "Empleados",
                principalColumn: "Ci",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_Empleados_CiEmpleado",
                table: "Administradores");

            migrationBuilder.AddColumn<int>(
                name: "Ci",
                table: "Administradores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Ci",
                table: "Administradores",
                column: "Ci",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_Empleados_Ci",
                table: "Administradores",
                column: "Ci",
                principalTable: "Empleados",
                principalColumn: "Ci",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
