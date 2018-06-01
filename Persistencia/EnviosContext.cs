namespace Persistencia
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EnviosContext : DbContext
    {
        public EnviosContext()
            : base("EnviosContext")
        {
        }

        public virtual DbSet<Adelantos> Adelantos { get; set; }
        public virtual DbSet<Automobiles> Automobiles { get; set; }
        public virtual DbSet<Balances> Balances { get; set; }
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
        public virtual DbSet<Registros> Registros { get; set; }
        public virtual DbSet<Reparaciones> Reparaciones { get; set; }
        public virtual DbSet<Sectores> Sectores { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<Administradores> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adelantos>()
                .Property(e => e.Suma)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Balances>()
                .HasMany(e => e.Registros)
                .WithRequired(e => e.Balances)
                .HasForeignKey(e => e.BalanceId);

            modelBuilder.Entity<Cadetes>()
                .Property(e => e.TipoLibreta)
                .IsUnicode(false);

            modelBuilder.Entity<Cadetes>()
                .HasMany(e => e.Vehiculos)
                .WithRequired(e => e.Cadetes)
                .HasForeignKey(e => e.Cadete);

            modelBuilder.Entity<Camiones>()
                .Property(e => e.Altura)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Casillas>()
                .HasMany(e => e.Palets)
                .WithRequired(e => e.Casillas)
                .HasForeignKey(e => e.Casilla);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Mensualidad)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Calificaciones)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.RutCliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Paquetes)
                .WithOptional(e => e.Clientes)
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Entregas)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.ClienteEmisor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Entregas1)
                .WithRequired(e => e.Clientes1)
                .HasForeignKey(e => e.ClienteReceptor);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Palets)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Paquetes1)
                .WithOptional(e => e.Clientes1)
                .HasForeignKey(e => e.Cliente);

            modelBuilder.Entity<Cuotas>()
                .Property(e => e.Suma)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Empleados>()
                .Property(e => e.Sueldo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.Adelantos)
                .WithRequired(e => e.Empleados)
                .HasForeignKey(e => e.Empleado);

            modelBuilder.Entity<Empleados>()
                .HasOptional(e => e.Cadetes)
                .WithRequired(e => e.Empleados)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.Administradores)
                .WithRequired(e => e.Empleados)
                .HasForeignKey(e => e.CiEmpleado);

            modelBuilder.Entity<Entregas>()
                .HasMany(e => e.Paquetes)
                .WithOptional(e => e.Entregas)
                .HasForeignKey(e => e.Entrega);

            modelBuilder.Entity<Entregas>()
                .HasMany(e => e.Paquetes1)
                .WithOptional(e => e.Entregas1)
                .HasForeignKey(e => e.Entrega)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Galpones>()
                .Property(e => e.Altura)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Galpones>()
                .Property(e => e.Superficie)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Galpones>()
                .HasMany(e => e.Sectores)
                .WithRequired(e => e.Galpones)
                .HasForeignKey(e => e.Galpon);

            modelBuilder.Entity<Gastos>()
                .Property(e => e.Suma)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Impuestos>()
                .Property(e => e.Porcentaje)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ingresos>()
                .Property(e => e.Suma)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Locales>()
                .HasMany(e => e.Entregas)
                .WithRequired(e => e.Locales)
                .HasForeignKey(e => e.LocalEmisor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Locales>()
                .HasMany(e => e.Entregas1)
                .WithRequired(e => e.Locales1)
                .HasForeignKey(e => e.LocalReceptor);

            modelBuilder.Entity<Motos>()
                .Property(e => e.Cilindrada)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Multas>()
                .Property(e => e.Suma)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Palets>()
                .Property(e => e.Peso)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Paquetes>()
                .HasMany(e => e.Reclamo)
                .WithRequired(e => e.Paquetes)
                .HasForeignKey(e => e.Paquete)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Paquetes>()
                .HasMany(e => e.Reclamo1)
                .WithRequired(e => e.Paquetes1)
                .HasForeignKey(e => e.Paquete);

            modelBuilder.Entity<Racks>()
                .Property(e => e.Altura)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Racks>()
                .Property(e => e.Superficie)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Racks>()
                .HasMany(e => e.Casillas)
                .WithRequired(e => e.Racks)
                .HasForeignKey(e => e.Rack);

            modelBuilder.Entity<Registros>()
                .Property(e => e.UtilidadBruta)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Registros>()
                .Property(e => e.UtilidadOperacional)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Registros>()
                .Property(e => e.UtilidadSinImpuestos)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Registros>()
                .Property(e => e.UtilidadEjercicio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Reparaciones>()
                .Property(e => e.Monto)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sectores>()
                .Property(e => e.Superficie)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sectores>()
                .HasMany(e => e.Racks)
                .WithRequired(e => e.Sectores)
                .HasForeignKey(e => e.Sector);

            modelBuilder.Entity<Turnos>()
                .HasMany(e => e.Entregas)
                .WithRequired(e => e.Turnos)
                .HasForeignKey(e => e.Turno);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Empleados)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuario);

            modelBuilder.Entity<Vehiculos>()
                .Property(e => e.Capacidad)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Vehiculos>()
                .HasOptional(e => e.Automobiles)
                .WithRequired(e => e.Vehiculos)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Vehiculos>()
                .HasOptional(e => e.Camiones)
                .WithRequired(e => e.Vehiculos)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Vehiculos>()
                .HasOptional(e => e.Camionetas)
                .WithRequired(e => e.Vehiculos)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Vehiculos>()
                .HasOptional(e => e.Motos)
                .WithRequired(e => e.Vehiculos)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Vehiculos>()
                .HasMany(e => e.Multas)
                .WithRequired(e => e.Vehiculos)
                .HasForeignKey(e => e.Vehiculo);

            modelBuilder.Entity<Vehiculos>()
                .HasMany(e => e.Reparaciones)
                .WithRequired(e => e.Vehiculos)
                .HasForeignKey(e => e.Vehiculo);

            modelBuilder.Entity<Administradores>()
                .Property(e => e.Tipo)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
