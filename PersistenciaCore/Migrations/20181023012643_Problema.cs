using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class Problema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaRegistro",
                table: "Reparaciones",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "RUT",
                table: "Ingresos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaRegistro",
                table: "Ingresos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaRegistro",
                table: "Impuestos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaRegistro",
                table: "Gastos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_RUT",
                table: "Ingresos",
                column: "RUT");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresos_Clientes_RUT",
                table: "Ingresos",
                column: "RUT",
                principalTable: "Clientes",
                principalColumn: "RUT",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresos_Clientes_RUT",
                table: "Ingresos");

            migrationBuilder.DropIndex(
                name: "IX_Ingresos_RUT",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "fechaRegistro",
                table: "Reparaciones");

            migrationBuilder.DropColumn(
                name: "RUT",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "fechaRegistro",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "fechaRegistro",
                table: "Impuestos");

            migrationBuilder.DropColumn(
                name: "fechaRegistro",
                table: "Gastos");

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abierto = table.Column<bool>(nullable: false),
                    Año = table.Column<int>(nullable: false),
                    Mes = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BalanceId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    UtilidadBruta = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    UtilidadEjercicio = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    UtilidadOperacional = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    UtilidadSinImpuestos = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Balances_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "Balances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_BalanceId",
                table: "Registros",
                column: "BalanceId");
        }
    }
}
