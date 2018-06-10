using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenciaCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Mes = table.Column<string>(maxLength: 10, nullable: false),
                    Año = table.Column<int>(nullable: false),
                    Abierto = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    Vencimiento = table.Column<DateTime>(type: "date", nullable: false),
                    IdAdelanto = table.Column<int>(nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Pagada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => new { x.IdAdelanto, x.Vencimiento });
                });

            migrationBuilder.CreateTable(
                name: "Galpones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Altura = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Superficie = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galpones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Impuestos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    Direccion = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Codigo = table.Column<string>(maxLength: 7, nullable: false),
                    Dia = table.Column<string>(maxLength: 10, nullable: false),
                    Hora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(maxLength: 25, nullable: false),
                    Contraseña = table.Column<string>(maxLength: 25, nullable: false),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    Direccion = table.Column<string>(maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    UtilidadBruta = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    UtilidadOperacional = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    UtilidadSinImpuestos = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    UtilidadEjercicio = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    BalanceId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false),
                    Superficie = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Temperatura = table.Column<int>(nullable: false),
                    Galpon = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sectores_Galpones_Galpon",
                        column: x => x.Galpon,
                        principalTable: "Galpones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    RUT = table.Column<long>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    Mensualidad = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.RUT);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Sueldo = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    Ci = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Ci);
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Superficie = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Sector = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Racks_Sectores_Sector",
                        column: x => x.Sector,
                        principalTable: "Sectores",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Puntaje = table.Column<int>(nullable: false),
                    RutCliente = table.Column<long>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => new { x.Id, x.RutCliente });
                    table.ForeignKey(
                        name: "FK_Calificaciones_Clientes_RutCliente",
                        column: x => x.RutCliente,
                        principalTable: "Clientes",
                        principalColumn: "RUT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    NombreReceptor = table.Column<string>(maxLength: 150, nullable: false),
                    ClienteReceptor = table.Column<long>(nullable: false),
                    ClienteEmisor = table.Column<long>(nullable: false),
                    LocalReceptor = table.Column<int>(nullable: false),
                    LocalEmisor = table.Column<int>(nullable: false),
                    Turno = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Entregas_Clientes_ClienteEmisor",
                        column: x => x.ClienteEmisor,
                        principalTable: "Clientes",
                        principalColumn: "RUT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entregas_Clientes_ClienteReceptor",
                        column: x => x.ClienteReceptor,
                        principalTable: "Clientes",
                        principalColumn: "RUT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entregas_Locales_LocalEmisor",
                        column: x => x.LocalEmisor,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entregas_Locales_LocalReceptor",
                        column: x => x.LocalReceptor,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entregas_Turnos_Turno",
                        column: x => x.Turno,
                        principalTable: "Turnos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adelantos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Empleado = table.Column<int>(nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    CantidadCuotas = table.Column<int>(nullable: false),
                    Saldado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adelantos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adelantos_Empleados_Empleado",
                        column: x => x.Empleado,
                        principalTable: "Empleados",
                        principalColumn: "Ci",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    CiEmpleado = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(type: "char(1)", unicode: false, maxLength: 1, nullable: false),
                    Ci = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.CiEmpleado);
                    table.ForeignKey(
                        name: "FK_Administradores_Empleados_Ci",
                        column: x => x.Ci,
                        principalTable: "Empleados",
                        principalColumn: "Ci",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cadetes",
                columns: table => new
                {
                    TipoLibreta = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    IdTelefono = table.Column<long>(nullable: false),
                    CiEmpleado = table.Column<int>(nullable: false),
                    Ci = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadetes", x => x.CiEmpleado);
                    table.ForeignKey(
                        name: "FK_Cadetes_Empleados_Ci",
                        column: x => x.Ci,
                        principalTable: "Empleados",
                        principalColumn: "Ci",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casillas",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false),
                    Rack = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casillas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Casillas_Racks_Rack",
                        column: x => x.Rack,
                        principalTable: "Racks",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    NumReferencia = table.Column<int>(nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "date", nullable: false),
                    Estado = table.Column<string>(maxLength: 15, nullable: false),
                    Ubicacion = table.Column<string>(maxLength: 100, nullable: false),
                    Entrega = table.Column<int>(nullable: true),
                    Cliente = table.Column<long>(nullable: true),
                    ClientesRUT = table.Column<long>(nullable: true),
                    EntregasCodigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.NumReferencia);
                    table.ForeignKey(
                        name: "FK_Paquetes_Clientes_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Clientes",
                        principalColumn: "RUT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquetes_Clientes_ClientesRUT",
                        column: x => x.ClientesRUT,
                        principalTable: "Clientes",
                        principalColumn: "RUT",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Paquetes_Entregas_Entrega",
                        column: x => x.Entrega,
                        principalTable: "Entregas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquetes_Entregas_EntregasCodigo",
                        column: x => x.EntregasCodigo,
                        principalTable: "Entregas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Matricula = table.Column<string>(maxLength: 10, nullable: false),
                    Marca = table.Column<string>(maxLength: 25, nullable: false),
                    Modelo = table.Column<string>(maxLength: 25, nullable: false),
                    Capacidad = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Estado = table.Column<string>(maxLength: 150, nullable: false),
                    Cadete = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Cadetes_Cadete",
                        column: x => x.Cadete,
                        principalTable: "Cadetes",
                        principalColumn: "CiEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Palets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Producto = table.Column<string>(maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Casilla = table.Column<int>(nullable: false),
                    Cliente = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palets", x => new { x.Id, x.Cliente });
                    table.UniqueConstraint("AK_Palets_Cliente_Id", x => new { x.Cliente, x.Id });
                    table.ForeignKey(
                        name: "FK_Palets_Casillas_Casilla",
                        column: x => x.Casilla,
                        principalTable: "Casillas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Palets_Clientes_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Clientes",
                        principalColumn: "RUT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reclamo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 250, nullable: false),
                    Paquete = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamo", x => new { x.Id, x.Paquete });
                    table.ForeignKey(
                        name: "FK_Reclamo_Paquetes_Id",
                        column: x => x.Id,
                        principalTable: "Paquetes",
                        principalColumn: "NumReferencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reclamo_Paquetes_Paquete",
                        column: x => x.Paquete,
                        principalTable: "Paquetes",
                        principalColumn: "NumReferencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Automobiles",
                columns: table => new
                {
                    Puertas = table.Column<int>(nullable: false),
                    MatriculaAuto = table.Column<string>(maxLength: 10, nullable: false),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobiles", x => x.MatriculaAuto);
                    table.ForeignKey(
                        name: "FK_Automobiles_Vehiculos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camiones",
                columns: table => new
                {
                    Altura = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    MatriculaCamion = table.Column<string>(maxLength: 10, nullable: false),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camiones", x => x.MatriculaCamion);
                    table.ForeignKey(
                        name: "FK_Camiones_Vehiculos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camionetas",
                columns: table => new
                {
                    Cabina = table.Column<string>(maxLength: 25, nullable: false),
                    MatriculaCamioneta = table.Column<string>(maxLength: 10, nullable: false),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camionetas", x => x.MatriculaCamioneta);
                    table.ForeignKey(
                        name: "FK_Camionetas_Vehiculos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    Cilindrada = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    MatriculaMoto = table.Column<string>(maxLength: 10, nullable: false),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.MatriculaMoto);
                    table.ForeignKey(
                        name: "FK_Motos_Vehiculos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Multas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Vehiculo = table.Column<string>(maxLength: 10, nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Motivo = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multas", x => new { x.Id, x.Vehiculo });
                    table.ForeignKey(
                        name: "FK_Multas_Vehiculos_Vehiculo",
                        column: x => x.Vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reparaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: false),
                    Taller = table.Column<string>(maxLength: 25, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    Vehiculo = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparaciones", x => new { x.Id, x.Vehiculo });
                    table.ForeignKey(
                        name: "FK_Reparaciones_Vehiculos_Vehiculo",
                        column: x => x.Vehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adelantos_Empleado",
                table: "Adelantos",
                column: "Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Ci",
                table: "Administradores",
                column: "Ci",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_Matricula",
                table: "Automobiles",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadetes_Ci",
                table: "Cadetes",
                column: "Ci",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_RutCliente",
                table: "Calificaciones",
                column: "RutCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Camiones_Matricula",
                table: "Camiones",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Camionetas_Matricula",
                table: "Camionetas",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Casillas_Rack",
                table: "Casillas",
                column: "Rack");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdUsuario",
                table: "Clientes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdUsuario",
                table: "Empleados",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_ClienteEmisor",
                table: "Entregas",
                column: "ClienteEmisor");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_ClienteReceptor",
                table: "Entregas",
                column: "ClienteReceptor");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_LocalEmisor",
                table: "Entregas",
                column: "LocalEmisor");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_LocalReceptor",
                table: "Entregas",
                column: "LocalReceptor");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_Turno",
                table: "Entregas",
                column: "Turno");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_Direccion",
                table: "Locales",
                column: "Direccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locales_Nombre",
                table: "Locales",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motos_Matricula",
                table: "Motos",
                column: "Matricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Multas_Vehiculo",
                table: "Multas",
                column: "Vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Palets_Casilla",
                table: "Palets",
                column: "Casilla");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_Cliente",
                table: "Paquetes",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_ClientesRUT",
                table: "Paquetes",
                column: "ClientesRUT");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_Entrega",
                table: "Paquetes",
                column: "Entrega");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_EntregasCodigo",
                table: "Paquetes",
                column: "EntregasCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Racks_Sector",
                table: "Racks",
                column: "Sector");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamo_Paquete",
                table: "Reclamo",
                column: "Paquete");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_BalanceId",
                table: "Registros",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_Vehiculo",
                table: "Reparaciones",
                column: "Vehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Sectores_Galpon",
                table: "Sectores",
                column: "Galpon");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Cadete",
                table: "Vehiculos",
                column: "Cadete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adelantos");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Automobiles");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Camiones");

            migrationBuilder.DropTable(
                name: "Camionetas");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Impuestos");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Multas");

            migrationBuilder.DropTable(
                name: "Palets");

            migrationBuilder.DropTable(
                name: "Reclamo");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Reparaciones");

            migrationBuilder.DropTable(
                name: "Casillas");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Racks");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Cadetes");

            migrationBuilder.DropTable(
                name: "Sectores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Galpones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
