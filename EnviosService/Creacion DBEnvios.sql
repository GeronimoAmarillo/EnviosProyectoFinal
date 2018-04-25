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

CREATE TABLE Vehculos
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