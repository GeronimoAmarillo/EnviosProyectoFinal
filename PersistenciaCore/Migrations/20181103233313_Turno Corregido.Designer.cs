﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistenciaCore;

namespace PersistenciaCore.Migrations
{
    [DbContext(typeof(EnviosContext))]
    [Migration("20181103233313_Turno Corregido")]
    partial class TurnoCorregido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersistenciaCore.Adelantos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadCuotas");

                    b.Property<int>("Empleado");

                    b.Property<bool>("Saldado");

                    b.Property<decimal>("Suma")
                        .HasColumnType("decimal(19,4)");

                    b.Property<DateTime>("fechaExpedido");

                    b.HasKey("Id");

                    b.HasIndex("Empleado");

                    b.ToTable("Adelantos");
                });

            modelBuilder.Entity("PersistenciaCore.Administradores", b =>
                {
                    b.Property<int>("CiEmpleado");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("char(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.HasKey("CiEmpleado");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("PersistenciaCore.Automobiles", b =>
                {
                    b.Property<string>("MatriculaAuto")
                        .HasMaxLength(10);

                    b.Property<int>("Puertas");

                    b.HasKey("MatriculaAuto");

                    b.ToTable("Automobiles");
                });

            modelBuilder.Entity("PersistenciaCore.Cadetes", b =>
                {
                    b.Property<int>("CiEmpleado");

                    b.Property<string>("Latitud");

                    b.Property<string>("Longitud");

                    b.Property<string>("TipoLibreta")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("CiEmpleado");

                    b.ToTable("Cadetes");
                });

            modelBuilder.Entity("PersistenciaCore.Calificaciones", b =>
                {
                    b.Property<int>("Id");

                    b.Property<long>("RutCliente");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("Puntaje");

                    b.HasKey("Id", "RutCliente");

                    b.HasIndex("RutCliente");

                    b.ToTable("Calificaciones");
                });

            modelBuilder.Entity("PersistenciaCore.Camiones", b =>
                {
                    b.Property<string>("MatriculaCamion")
                        .HasMaxLength(10);

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("MatriculaCamion");

                    b.ToTable("Camiones");
                });

            modelBuilder.Entity("PersistenciaCore.Camionetas", b =>
                {
                    b.Property<string>("MatriculaCamioneta")
                        .HasMaxLength(10);

                    b.Property<string>("Cabina")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("MatriculaCamioneta");

                    b.ToTable("Camionetas");
                });

            modelBuilder.Entity("PersistenciaCore.Casillas", b =>
                {
                    b.Property<int>("Codigo");

                    b.Property<int>("Rack");

                    b.HasKey("Codigo");

                    b.HasIndex("Rack");

                    b.ToTable("Casillas");
                });

            modelBuilder.Entity("PersistenciaCore.Clientes", b =>
                {
                    b.Property<long>("RUT");

                    b.Property<int>("IdUsuario");

                    b.Property<decimal>("Mensualidad")
                        .HasColumnType("decimal(19, 4)");

                    b.HasKey("RUT");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PersistenciaCore.Cuotas", b =>
                {
                    b.Property<int>("IdAdelanto");

                    b.Property<DateTime>("Vencimiento")
                        .HasColumnType("date");

                    b.Property<bool>("Pagada");

                    b.Property<decimal>("Suma")
                        .HasColumnType("decimal(19, 4)");

                    b.HasKey("IdAdelanto", "Vencimiento");

                    b.ToTable("Cuotas");
                });

            modelBuilder.Entity("PersistenciaCore.Empleados", b =>
                {
                    b.Property<int>("Ci");

                    b.Property<int>("IdUsuario");

                    b.Property<decimal>("Sueldo")
                        .HasColumnType("decimal(19, 4)");

                    b.HasKey("Ci");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("PersistenciaCore.Entregas", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Cadete");

                    b.Property<int?>("CadetesCiEmpleado");

                    b.Property<long?>("ClienteEmisor");

                    b.Property<long?>("ClienteReceptor");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int?>("LocalEmisor");

                    b.Property<int?>("LocalReceptor");

                    b.Property<string>("NombreReceptor")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.HasKey("Codigo");

                    b.HasIndex("CadetesCiEmpleado");

                    b.HasIndex("ClienteEmisor");

                    b.HasIndex("ClienteReceptor");

                    b.HasIndex("LocalEmisor");

                    b.HasIndex("LocalReceptor");

                    b.HasIndex("Turno");

                    b.ToTable("Entregas");
                });

            modelBuilder.Entity("PersistenciaCore.Galpones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("Superficie")
                        .HasColumnType("decimal(19, 4)");

                    b.HasKey("Id");

                    b.ToTable("Galpones");
                });

            modelBuilder.Entity("PersistenciaCore.Gastos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<decimal>("Suma")
                        .HasColumnType("decimal(19, 4)");

                    b.Property<DateTime>("fechaRegistro")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("PersistenciaCore.Impuestos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Porcentaje")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime>("fechaRegistro")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Impuestos");
                });

            modelBuilder.Entity("PersistenciaCore.Ingresos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<long?>("RUT");

                    b.Property<decimal>("Suma")
                        .HasColumnType("decimal(19, 4)");

                    b.Property<DateTime>("fechaRegistro")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("RUT");

                    b.ToTable("Ingresos");
                });

            modelBuilder.Entity("PersistenciaCore.Locales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("Direccion")
                        .IsUnique();

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Locales");
                });

            modelBuilder.Entity("PersistenciaCore.Motos", b =>
                {
                    b.Property<string>("MatriculaMoto")
                        .HasMaxLength(10);

                    b.Property<decimal>("Cilindrada")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("MatriculaMoto");

                    b.ToTable("Motos");
                });

            modelBuilder.Entity("PersistenciaCore.Multas", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Vehiculo")
                        .HasMaxLength(10);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Suma")
                        .HasColumnType("decimal(19, 4)");

                    b.HasKey("Id", "Vehiculo");

                    b.HasIndex("Vehiculo");

                    b.ToTable("Multas");
                });

            modelBuilder.Entity("PersistenciaCore.Palets", b =>
                {
                    b.Property<int>("Id");

                    b.Property<long>("Cliente");

                    b.Property<int>("Cantidad");

                    b.Property<int>("Casilla");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id", "Cliente");

                    b.HasAlternateKey("Cliente", "Id");

                    b.HasIndex("Casilla");

                    b.ToTable("Palets");
                });

            modelBuilder.Entity("PersistenciaCore.Paquetes", b =>
                {
                    b.Property<int>("NumReferencia");

                    b.Property<long?>("Cliente");

                    b.Property<long?>("ClientesRUT");

                    b.Property<int?>("Entrega");

                    b.Property<int?>("EntregasCodigo");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("date");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("NumReferencia");

                    b.HasIndex("Cliente");

                    b.HasIndex("ClientesRUT");

                    b.HasIndex("Entrega");

                    b.HasIndex("EntregasCodigo");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("PersistenciaCore.Racks", b =>
                {
                    b.Property<int>("Codigo");

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Sector");

                    b.Property<decimal>("Superficie")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Codigo");

                    b.HasIndex("Sector");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("PersistenciaCore.Reclamo", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Paquete");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id", "Paquete");

                    b.HasIndex("Paquete");

                    b.ToTable("Reclamo");
                });

            modelBuilder.Entity("PersistenciaCore.Reparaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Vehiculo")
                        .HasMaxLength(10);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(19, 4)");

                    b.Property<string>("Taller")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("fechaRegistro")
                        .HasColumnType("date");

                    b.HasKey("Id", "Vehiculo");

                    b.HasIndex("Vehiculo");

                    b.ToTable("Reparaciones");
                });

            modelBuilder.Entity("PersistenciaCore.Sectores", b =>
                {
                    b.Property<int>("Codigo");

                    b.Property<int>("Galpon");

                    b.Property<decimal>("Superficie")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Temperatura");

                    b.HasKey("Codigo");

                    b.HasIndex("Galpon");

                    b.ToTable("Sectores");
                });

            modelBuilder.Entity("PersistenciaCore.Turnos", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7);

                    b.Property<string>("Dia")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<bool>("Eliminado");

                    b.Property<int>("Hora");

                    b.HasKey("Codigo");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("PersistenciaCore.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoModificarEmail")
                        .HasMaxLength(5);

                    b.Property<string>("CodigoRecuperacionContraseña")
                        .HasMaxLength(5);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("NombreUsuario")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PersistenciaCore.Vehiculos", b =>
                {
                    b.Property<string>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int>("Cadete");

                    b.Property<decimal>("Capacidad")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Matricula");

                    b.HasIndex("Cadete");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("PersistenciaCore.Adelantos", b =>
                {
                    b.HasOne("PersistenciaCore.Empleados", "Empleados")
                        .WithMany("Adelantos")
                        .HasForeignKey("Empleado")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Administradores", b =>
                {
                    b.HasOne("PersistenciaCore.Empleados", "Empleados")
                        .WithOne("Administradores")
                        .HasForeignKey("PersistenciaCore.Administradores", "CiEmpleado")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Automobiles", b =>
                {
                    b.HasOne("PersistenciaCore.Vehiculos", "Vehiculos")
                        .WithOne("Automobiles")
                        .HasForeignKey("PersistenciaCore.Automobiles", "MatriculaAuto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Cadetes", b =>
                {
                    b.HasOne("PersistenciaCore.Empleados", "Empleados")
                        .WithOne("Cadetes")
                        .HasForeignKey("PersistenciaCore.Cadetes", "CiEmpleado")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Calificaciones", b =>
                {
                    b.HasOne("PersistenciaCore.Clientes", "Clientes")
                        .WithMany("Calificaciones")
                        .HasForeignKey("RutCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Camiones", b =>
                {
                    b.HasOne("PersistenciaCore.Vehiculos", "Vehiculos")
                        .WithOne("Camiones")
                        .HasForeignKey("PersistenciaCore.Camiones", "MatriculaCamion")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Camionetas", b =>
                {
                    b.HasOne("PersistenciaCore.Vehiculos", "Vehiculos")
                        .WithOne("Camionetas")
                        .HasForeignKey("PersistenciaCore.Camionetas", "MatriculaCamioneta")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Casillas", b =>
                {
                    b.HasOne("PersistenciaCore.Racks", "Racks")
                        .WithMany("Casillas")
                        .HasForeignKey("Rack")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Clientes", b =>
                {
                    b.HasOne("PersistenciaCore.Usuarios", "Usuarios")
                        .WithMany("Clientes")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Empleados", b =>
                {
                    b.HasOne("PersistenciaCore.Usuarios", "Usuarios")
                        .WithMany("Empleados")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Entregas", b =>
                {
                    b.HasOne("PersistenciaCore.Cadetes", "Cadetes")
                        .WithMany("Entregas")
                        .HasForeignKey("CadetesCiEmpleado");

                    b.HasOne("PersistenciaCore.Clientes", "Clientes")
                        .WithMany("Entregas")
                        .HasForeignKey("ClienteEmisor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PersistenciaCore.Clientes", "Clientes1")
                        .WithMany("Entregas1")
                        .HasForeignKey("ClienteReceptor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PersistenciaCore.Locales", "Locales")
                        .WithMany("Entregas")
                        .HasForeignKey("LocalEmisor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PersistenciaCore.Locales", "Locales1")
                        .WithMany("Entregas1")
                        .HasForeignKey("LocalReceptor")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PersistenciaCore.Turnos", "Turnos")
                        .WithMany("Entregas")
                        .HasForeignKey("Turno")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PersistenciaCore.Ingresos", b =>
                {
                    b.HasOne("PersistenciaCore.Clientes", "Clientes")
                        .WithMany("Ingresos")
                        .HasForeignKey("RUT");
                });

            modelBuilder.Entity("PersistenciaCore.Motos", b =>
                {
                    b.HasOne("PersistenciaCore.Vehiculos", "Vehiculos")
                        .WithOne("Motos")
                        .HasForeignKey("PersistenciaCore.Motos", "MatriculaMoto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Multas", b =>
                {
                    b.HasOne("PersistenciaCore.Vehiculos", "Vehiculos")
                        .WithMany("Multas")
                        .HasForeignKey("Vehiculo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Palets", b =>
                {
                    b.HasOne("PersistenciaCore.Casillas", "Casillas")
                        .WithMany("Palets")
                        .HasForeignKey("Casilla")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PersistenciaCore.Clientes", "Clientes")
                        .WithMany("Palets")
                        .HasForeignKey("Cliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Paquetes", b =>
                {
                    b.HasOne("PersistenciaCore.Clientes", "Clientes1")
                        .WithMany("Paquetes1")
                        .HasForeignKey("Cliente");

                    b.HasOne("PersistenciaCore.Clientes", "Clientes")
                        .WithMany("Paquetes")
                        .HasForeignKey("ClientesRUT");

                    b.HasOne("PersistenciaCore.Entregas", "Entregas1")
                        .WithMany("Paquetes1")
                        .HasForeignKey("Entrega")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PersistenciaCore.Entregas", "Entregas")
                        .WithMany("Paquetes")
                        .HasForeignKey("EntregasCodigo");
                });

            modelBuilder.Entity("PersistenciaCore.Racks", b =>
                {
                    b.HasOne("PersistenciaCore.Sectores", "Sectores")
                        .WithMany("Racks")
                        .HasForeignKey("Sector")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Reclamo", b =>
                {
                    b.HasOne("PersistenciaCore.Paquetes", "Paquetes")
                        .WithMany("Reclamo")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PersistenciaCore.Paquetes", "Paquetes1")
                        .WithMany("Reclamo1")
                        .HasForeignKey("Paquete")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PersistenciaCore.Reparaciones", b =>
                {
                    b.HasOne("PersistenciaCore.Vehiculos", "Vehiculos")
                        .WithMany("Reparaciones")
                        .HasForeignKey("Vehiculo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Sectores", b =>
                {
                    b.HasOne("PersistenciaCore.Galpones", "Galpones")
                        .WithMany("Sectores")
                        .HasForeignKey("Galpon")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersistenciaCore.Vehiculos", b =>
                {
                    b.HasOne("PersistenciaCore.Cadetes", "Cadetes")
                        .WithMany("Vehiculos")
                        .HasForeignKey("Cadete")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
