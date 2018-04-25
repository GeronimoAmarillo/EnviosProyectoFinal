USE MASTER
GO

IF exists(SELECT * FROM SysDataBases WHERE name='Envios')
BEGIN
 DROP DATABASE Envios
END
go

CREATE DATABASE Envios
go

USE Envios
go

CREATE TABLE Usuarios
(
	Id Integer Primary Key,
	NombreUsuario NVarchar(25) Unique not null,
	Contraseña NVarchar(25) not null,
	Nombre NVarchar(40) not null,
	Direccion NVarchar(150) not null,
	Telefono NVarchar(25) not null,
	Email NVarchar(150) not null

)

CREATE TABLE Empleados
(
	Sueldo money not null,
	Ci Integer not null,
	IdUsuario Integer foreign key references Usuarios(Id),
)

CREATE TABLE Administradores
(
	CiEmpleado Integer foreign key references Empleados(Ci),
	IdEmpleado Integer foreign key references Empleados(IdUsuario),
	Tipo char not null,
	primary key (CiEmpleado, IdEmpleado)

)

CREATE TABLE Cadetes
(
	TipoLibreta Varchar(2) not null,
	IdTelefono BigInt not null,
	CiEmpleado Integer foreign key references Empleados(Ci),
	IdEmpleado Integer foreign key references Empleados(IdUsuario),
	primary key (CiEmpleado, IdEmpleado)

)

CREATE TABLE Clientes
(
	RUT bigint unique not null,
	Mensualidad money not null,
	IdUsuario Integer foreign key references Usuarios(Id),
	primary key (RUT, IdUsuario)
)

CREATE TABLE Vehiculos
(
	Matricula NVarchar(10) primary key,
	Marca NVarchar(25) not null,
	Modelo NVarchar(25) not null,
	Capacidad decimal not null,
	Estado NVarchar(150) not null
)

CREATE TABLE Automobiles
(
	Puertas int not null,
	MatriculaAuto NVarchar(10) foreign key references Vehiculos(Matricula) primary key
)

CREATE TABLE Motos
(
	Cilindrada decimal not null,
	MatriculaMoto NVarchar(10) foreign key references Vehiculos(Matricula) primary key
)

CREATE TABLE Camiones
(
	Altura decimal not null,
	MatriculaCamion NVarchar(10) foreign key references Vehiculos(Matricula) primary key
)

CREATE TABLE Camionetas
(
	Cabina NVarchar(25) not null,
	MatriculaCamioneta NVarchar(10) foreign key references Vehiculos(Matricula) primary key
)

CREATE TABLE Reparaciones
(
	Id integer identity (1,1),
	Descripcion NVarchar(150) not null,
	Taller NVarchar(25) not null,
	Monto money not null,
	Vehiculo NVarchar(10) foreign key references Vehiculos(Matricula),
	Primary Key (Id, Vehiculo)
)

CREATE TABLE Multas
(
	Id Integer identity(1,1),
	Vehiculo NVarchar(10) foreign key references Vehiculos(Matricula),
	Suma money not null,
	Fecha date not null,
	Motivo NVarchar(150) not null,
	Primary Key (Id, Vehculo)

)

CREATE TABLE Adelantos
(
	Id integer identity(1,1),
	Empleado integer foreign key references Empleados(Ci),
	Suma money not null,
	CantidadCuotas int not null,
	Saldado bit not null default(0),
	Primary Key (Id, Empleado)

)

CREATE TABLE Cuotas
(
	Vencimiento date not null,
	IdAdelanto integer foreign key references Adelantos(Id),
	Suma money not null,
	Pagada bit not null default(0),
	Primary Key (Vencimiento, IdAdelanto)

)

CREATE TABLE Calificaciones
(
	Id integer identity(1,1) Primary Key,
	Puntaje int not null,
	IdCliente Integer foreign key references Clientes(Id),
	RutCliente Integer foreign key references Clientes(Rut),
	Comentario NVarchar(250) not null,
	Primary Key (Id, IdCliente, RutCliente)

)

CREATE TABLE Galpones
(
	Id Integer identity(1,1) primary key,
	Altura Decimal not null,
	Superficie Decimal not null
)

CREATE TABLE Sectores
(
	Codigo Integer not null,
	Superficie Decimal not null,
	Temperatura Integer not null,
	Galpon Integer foreign key references Galpones(Id),
	primary key(Codigo, Galpon)
)

CREATE TABLE Racks
(
	Codigo Integer not null,
	Altura Decimal not null,
	Superficie Decimal not null,
	Sector Integer foreign key references Sectores(Codigo),
	Galpon Integer foreign key references Sectores(Galpon),
	primary key (Codigo, Sector, Galpon)
)

CREATE TABLE Casillas
(
	Codigo Integer not null,
	Rack Integer foreign key references Racks(Codigo),
	primary key(Codigo, Rack)
)

CREATE TABLE Palets
(
	Id Integer identity(1,1) primary key,
	Producto NVarchar(100) not null,
	Cantidad Integer not null,
	Peso Decimal not null,
	Cliente Integer foreign key references Clientes(RUT) not null,
	Casilla Integer foreign key references Casillas(Codigo)
)

CREATE TABLE Gastos
(
	Id Integer identity(1,1) primary key,
	Descripcion Nvarchar(250) not null,
	Suma money not null
)

CREATE TABLE Impuestos
(
	Id Integer identity(1,1) primary key,
	Descripcion Nvarchar(250) not null,
	Porcentaje decimal not null,
	Nombre Nvarchar(50) not null
)

CREATE TABLE Ingresos
(
	Id Integer identity(1,1) primary key,
	Descripcion Nvarchar(250) not null,
	Suma money not null
)

CREATE TABLE Balances
(
	Id Integer identity (1,1) not null,
	Mes Nvarchar (10) not null,
	Año Integer not null,
	Abierto bit not null default(0),
	Primary key(Id, Mes, Año)
)

CREATE TABLE Registros
(
	Id Integer identity (1,1) not null,
	Fecha date not null,
	UtilidadBruta money not null,
	UtilidadOperacional money not null,
	UtilidadSinImpuestos money not null,
	UtilidadEjercicio money not null,
	BalanceId integer foreign key references Balances(Id),
	BalanceMes Nvarchar(10) foreign key references Balances(Mes),
	BalanceAño Integer foreign key references Balances(Año),
	primary key (Id, Fecha, BalanceId, BalanceMes, BalanceAño)
)

CREATE TABLE Locales
(
	Id Integer identity(1,1) primary key,
	Nombre Nvarchar(150) unique not null,
	Direccion Nvarchar(200) unique not null
)

CREATE TABLE Turnos
(
	Codigo Nvarchar(7) primary key,
	Dia Nvarchar(10) not null,
	Hora Integer not null
)

CREATE TABLE Entregas
(
	Codigo integer identity(1,1) primary key,
	Fecha date not null,
	NombreReceptor Nvarchar(150) not null,
	ClienteReceptor integer foreign key references Clientes(RUT),
	ClienteEmisor integer foreign key references Clientes(RUT),
	LocalReceptor integer foreign key references Locales(Id),
	LocalEmisor integer foreign key references Locales(Id),
	Turno Nvarchar(7) foreign key references Turnos(Codigo)
)

CREATE TABLE Paquetes
(
	NumReferencia Integer not null,
	FechaSalida date not null,
	Estado Nvarchar(15) not null,
	Ubicacion Nvarchar(100) not null,
	Entrega Integer foreign key references Entregas(Codigo),
	Cliente Integer foreign key references Clientes(RUT),
	primary key(NumReferencia, Cliente)
)

CREATE TABLE Reclamo
(	
	Id integer identity(1,1) not null,
	Comentario Nvarchar(250) not null,
	Paquete integer foreign key references Paquetes(NumReferencia) not null,
	Cliente integer foreign key references Paquetes(Cliente) not null,
	Entrega integer foreign key references Paquetes(Entrega) not null,
	primary key(Id, Paquete)
)