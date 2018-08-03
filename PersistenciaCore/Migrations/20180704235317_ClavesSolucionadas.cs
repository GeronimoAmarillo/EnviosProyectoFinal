using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class ClavesSolucionadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobiles_Vehiculos_Matricula",
                table: "Automobiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Cadetes_Empleados_Ci",
                table: "Cadetes");

            migrationBuilder.DropForeignKey(
                name: "FK_Camiones_Vehiculos_Matricula",
                table: "Camiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Camionetas_Vehiculos_Matricula",
                table: "Camionetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Vehiculos_Matricula",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Motos_Matricula",
                table: "Motos");

            migrationBuilder.DropIndex(
                name: "IX_Camionetas_Matricula",
                table: "Camionetas");

            migrationBuilder.DropIndex(
                name: "IX_Camiones_Matricula",
                table: "Camiones");

            migrationBuilder.DropIndex(
                name: "IX_Cadetes_Ci",
                table: "Cadetes");

            migrationBuilder.DropIndex(
                name: "IX_Automobiles_Matricula",
                table: "Automobiles");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Camionetas");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Camiones");

            migrationBuilder.DropColumn(
                name: "Ci",
                table: "Cadetes");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Automobiles");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobiles_Vehiculos_MatriculaAuto",
                table: "Automobiles",
                column: "MatriculaAuto",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cadetes_Empleados_CiEmpleado",
                table: "Cadetes",
                column: "CiEmpleado",
                principalTable: "Empleados",
                principalColumn: "Ci",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Camiones_Vehiculos_MatriculaCamion",
                table: "Camiones",
                column: "MatriculaCamion",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Camionetas_Vehiculos_MatriculaCamioneta",
                table: "Camionetas",
                column: "MatriculaCamioneta",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Vehiculos_MatriculaMoto",
                table: "Motos",
                column: "MatriculaMoto",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobiles_Vehiculos_MatriculaAuto",
                table: "Automobiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Cadetes_Empleados_CiEmpleado",
                table: "Cadetes");

            migrationBuilder.DropForeignKey(
                name: "FK_Camiones_Vehiculos_MatriculaCamion",
                table: "Camiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Camionetas_Vehiculos_MatriculaCamioneta",
                table: "Camionetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Vehiculos_MatriculaMoto",
                table: "Motos");

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Motos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Camionetas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Camiones",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ci",
                table: "Cadetes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Automobiles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_Matricula",
                table: "Motos",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Camionetas_Matricula",
                table: "Camionetas",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Camiones_Matricula",
                table: "Camiones",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadetes_Ci",
                table: "Cadetes",
                column: "Ci",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_Matricula",
                table: "Automobiles",
                column: "Matricula",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobiles_Vehiculos_Matricula",
                table: "Automobiles",
                column: "Matricula",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cadetes_Empleados_Ci",
                table: "Cadetes",
                column: "Ci",
                principalTable: "Empleados",
                principalColumn: "Ci",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Camiones_Vehiculos_Matricula",
                table: "Camiones",
                column: "Matricula",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Camionetas_Vehiculos_Matricula",
                table: "Camionetas",
                column: "Matricula",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Vehiculos_Matricula",
                table: "Motos",
                column: "Matricula",
                principalTable: "Vehiculos",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
