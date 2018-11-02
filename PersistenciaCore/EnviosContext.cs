namespace PersistenciaCore
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnviosContext : DbContext
    {

        public EnviosContext(DbContextOptions<EnviosContext> options)
            : base(options)
        { }

        public virtual DbSet<Adelantos> Adelantos { get; set; }
        public virtual DbSet<Automobiles> Automobiles { get; set; }
        public virtual DbSet<Cadetes> Cadetes { get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }
        public virtual DbSet<Camiones> Camiones { get; set; }
        public virtual DbSet<Camionetas> Camionetas { get; set; }
        public virtual DbSet<Casillas> Casillas { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Cuotas> Cuotas { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Entregas> Entregas { get; set; }
        public virtual DbSet<Galpones> Galpones { get; set; }
        public virtual DbSet<Gastos> Gastos { get; set; }
        public virtual DbSet<Impuestos> Impuestos { get; set; }
        public virtual DbSet<Ingresos> Ingresos { get; set; }
        public virtual DbSet<Locales> Locales { get; set; }
        public virtual DbSet<Motos> Motos { get; set; }
        public virtual DbSet<Multas> Multas { get; set; }
        public virtual DbSet<Palets> Palets { get; set; }
        public virtual DbSet<Paquetes> Paquetes { get; set; }
        public virtual DbSet<Racks> Racks { get; set; }
        public virtual DbSet<Reclamo> Reclamo { get; set; }
        public virtual DbSet<Reparaciones> Reparaciones { get; set; }
        public virtual DbSet<Sectores> Sectores { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<Administradores> Administradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entregas>()
                .HasOne(x => x.Cadetes)
                .WithMany(x => x.Entregas);

            modelBuilder.Entity<Adelantos>()
                .Property(e => e.Suma)
                .HasColumnType("decimal(19,4)");

            modelBuilder.Entity<Cadetes>()
                .Property(e => e.TipoLibreta)
                .IsUnicode(false);

            modelBuilder.Entity<Cadetes>()
                .HasMany(e => e.Vehiculos)
                .WithOne(e => e.Cadetes)
                .IsRequired()
                .HasForeignKey(e => e.Cadete);

            modelBuilder.Entity<Camiones>()
                .Property(e => e.Altura)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Casillas>()
                .HasMany(e => e.Palets)
                .WithOne(e => e.Casillas).IsRequired()
                .HasForeignKey(e => e.Casilla);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Mensualidad)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Calificaciones)
                .WithOne(e => e.Clientes).IsRequired()
                .HasForeignKey(e => e.RutCliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Paquetes)
                .WithOne(e => e.Clientes)
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Entregas)
                .WithOne(e => e.Clientes)
                .HasForeignKey(e => e.ClienteEmisor).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Entregas1)
                .WithOne(e => e.Clientes1)
                .HasForeignKey(e => e.ClienteReceptor).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Palets)
                .WithOne(e => e.Clientes).IsRequired()
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Paquetes1)
                .WithOne(e => e.Clientes1)
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<Cuotas>()
                .Property(e => e.Suma)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Sueldo)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.Adelantos)
                .WithOne(e => e.Empleados).IsRequired()
                .HasForeignKey(e => e.Empleado);
           

            modelBuilder.Entity<Cadetes>()
                .HasOne(e => e.Empleados)
                .WithOne(e => e.Cadetes).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Administradores>()
                .HasOne(e => e.Empleados)
                .WithOne(e => e.Administradores).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Empleados>()
                .HasOne(e => e.Administradores)
                .WithOne(e => e.Empleados).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Entregas>()
                .HasMany(e => e.Paquetes)
                .WithOne(e => e.Entregas)
                .HasForeignKey(e => e.Entrega);

            modelBuilder.Entity<Entregas>()
                .HasMany(e => e.Paquetes1)
                .WithOne(e => e.Entregas1)
                .HasForeignKey(e => e.Entrega)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Galpones>()
                .Property(e => e.Altura)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Galpones>()
                .Property(e => e.Superficie)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Galpones>()
                .HasMany(e => e.Sectores)
                .WithOne(e => e.Galpones).IsRequired()
                .HasForeignKey(e => e.Galpon);

            modelBuilder.Entity<Gastos>()
                .Property(e => e.Suma)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Impuestos>()
                .Property(e => e.Porcentaje)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Ingresos>()
                .Property(e => e.Suma)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Locales>()
                .HasMany(e => e.Entregas)
                .WithOne(e => e.Locales)
                .HasForeignKey(e => e.LocalEmisor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Locales>()
                .HasMany(e => e.Entregas1)
                .WithOne(e => e.Locales1)
                .HasForeignKey(e => e.LocalReceptor).
                OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Locales>()
                .HasIndex(u => u.Nombre)
                .IsUnique();

            modelBuilder.Entity<Locales>()
                .HasIndex(u => u.Direccion)
                .IsUnique();

            modelBuilder.Entity<Motos>()
                .Property(e => e.Cilindrada)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Multas>()
                .Property(e => e.Suma)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Palets>()
                .Property(e => e.Peso)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Paquetes>()
                .HasMany(e => e.Reclamo)
                .WithOne(e => e.Paquetes).IsRequired()
                .HasForeignKey(e => e.Paquete)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Paquetes>()
                .HasMany(e => e.Reclamo1)
                .WithOne(e => e.Paquetes1).IsRequired()
                .HasForeignKey(e => e.Paquete)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Racks>()
                .Property(e => e.Altura)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Racks>()
                .Property(e => e.Superficie)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Racks>()
                .HasMany(e => e.Casillas)
                .WithOne(e => e.Racks).IsRequired()
                .HasForeignKey(e => e.Rack);

            modelBuilder.Entity<Reparaciones>()
                .Property(e => e.Monto)
                .HasColumnType("decimal(19, 4)");

            modelBuilder.Entity<Sectores>()
                .Property(e => e.Superficie)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Sectores>()
                .HasMany(e => e.Racks)
                .WithOne(e => e.Sectores).IsRequired()
                .HasForeignKey(e => e.Sector);

            modelBuilder.Entity<Turnos>()
                .HasMany(e => e.Entregas)
                .WithOne(e => e.Turnos).IsRequired()
                .HasForeignKey(e => e.Turno).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Clientes)
                .WithOne(e => e.Usuarios).IsRequired()
                .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Empleados)
                .WithOne(e => e.Usuarios).IsRequired()
                .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Capacidad)
                .HasColumnType("decimal(18, 0)");

            modelBuilder.Entity<Vehiculos>()
                .HasOne(e => e.Automobiles)
                .WithOne(e => e.Vehiculos).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehiculos>()
                .HasOne(e => e.Camiones)
                .WithOne(e => e.Vehiculos).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehiculos>()
                .HasOne(e => e.Camionetas)
                .WithOne(e => e.Vehiculos).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehiculos>()
                .HasOne(e => e.Motos)
                .WithOne(e => e.Vehiculos).IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehiculos>()
                .HasMany(e => e.Multas)
                .WithOne(e => e.Vehiculos).IsRequired()
                .HasForeignKey(e => e.Vehiculo);

            modelBuilder.Entity<Vehiculos>()
                .HasMany(e => e.Reparaciones)
                .WithOne(e => e.Vehiculos).IsRequired()
                .HasForeignKey(e => e.Vehiculo);

            modelBuilder.Entity<Administradores>()
                .Property(e => e.Tipo)
                .HasColumnType("char(1)")
                .IsUnicode(false);

            modelBuilder.Entity<Calificaciones>()
            .HasKey(c => new { c.Id, c.RutCliente});

            modelBuilder.Entity<Cuotas>()
            .HasKey(c => new { c.IdAdelanto, c.Vencimiento });

            modelBuilder.Entity<Multas>()
            .HasKey(c => new { c.Id, c.Vehiculo });

            modelBuilder.Entity<Palets>()
            .HasKey(c => new { c.Id, c.Cliente });

            modelBuilder.Entity<Reclamo>()
            .HasKey(c => new { c.Id, c.Paquete });

            modelBuilder.Entity<Reparaciones>()
            .HasKey(c => new { c.Id, c.Vehiculo });

            
        }
    }
}
