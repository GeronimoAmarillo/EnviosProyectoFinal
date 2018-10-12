using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class AgregadosValoresVeri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoModificarEmail",
                table: "Usuarios",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoRecuperacionContraseña",
                table: "Usuarios",
                maxLength: 5,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
