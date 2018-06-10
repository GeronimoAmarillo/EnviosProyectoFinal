USE MASTER
GO

IF exists(SELECT * FROM SysDataBases WHERE name='EnviosPrueba')
BEGIN
 DROP DATABASE EnviosPrueba
END
go

CREATE DATABASE EnviosPrueba
go

USE EnviosPrueba
go

CREATE TABLE Usuarios
(
	Id Integer Identity (1,1) not null,
	NombreUsuario NVarchar(25) Unique not null,
	Contraseña NVarchar(25) not null,
	Nombre NVarchar(40) not null,
	Direccion NVarchar(150) not null,
	Telefono NVarchar(25) not null,
	Email NVarchar(150) not null,
	Constraint PK_Usuarios PRIMARY KEY (Id)

)

CREATE TABLE [Empleados]
(
	Sueldo money not null,
	IdUsuario Integer not null,
	Ci integer not null,
	Constraint PK_Empleados PRIMARY KEY (Ci),
	CONSTRAINT FK_Empleados_Usuarios_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id) ON DELETE CASCADE
)


CREATE TABLE Administradores
(
	CiEmpleado Integer not null,
	Tipo char not null,
	CONSTRAINT FK_Administradores_Empleados_CiEmpleado FOREIGN KEY (CiEmpleado) REFERENCES Empleados (Ci) ON DELETE CASCADE
)

CREATE TABLE Cadetes
(
	TipoLibreta Varchar(2) not null,
	IdTelefono BigInt not null,
	CiEmpleado Integer not null,
	constraint FK_Cadetes_Empleados_CiEmpleado FOREIGN KEY (CiEmpleado) REFERENCES Empleados (Ci) ON DELETE CASCADE,
	constraint PK_Cadetes primary key(CiEmpleado)
)

CREATE TABLE Clientes
(
	RUT bigint not null,
	IdUsuario Integer not null,
	Mensualidad money not null,
	constraint PK_Clientes Primary key (RUT),
	constraint FK_Clientes_Usuarios_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id) ON DELETE CASCADE
)

CREATE TABLE Vehiculos
(
	Matricula NVarchar(10)  not null,
	Marca NVarchar(25) not null,
	Modelo NVarchar(25) not null,
	Capacidad decimal not null,
	Estado NVarchar(150) not null,
	Cadete Integer not null,
	constraint PK_Vehiculos primary key(Matricula),
	constraint FK_Vehiculos_Cadetes_Cadete FOREIGN KEY (Cadete) REFERENCES Cadetes (CiEmpleado) ON DELETE CASCADE
)

CREATE TABLE Automobiles
(
	Puertas int not null,
	MatriculaAuto NVarchar(10) not null,
	constraint FK_Automobiles_Vehiculos_MatriculaAuto FOREIGN KEY (MatriculaAuto) REFERENCES Vehiculos (Matricula) ON DELETE CASCADE,
	constraint PK_Automobiles primary key(MatriculaAuto)
)

CREATE TABLE Motos
(
	Cilindrada decimal not null,
	MatriculaMoto NVarchar(10) not null,
	constraint FK_Motos_Vehiculos_MatriculaMoto FOREIGN KEY (MatriculaMoto) REFERENCES Vehiculos (Matricula) ON DELETE CASCADE,
	constraint PK_Motos primary key(MatriculaMoto)
)

CREATE TABLE Camiones
(
	Altura decimal not null,
	MatriculaCamion NVarchar(10) not null,
	constraint FK_Camiones_Vehiculos_MatriculaCamion FOREIGN KEY (MatriculaCamion) REFERENCES Vehiculos (Matricula) ON DELETE CASCADE,
	constraint PK_Camiones primary key(MatriculaCamion)
)

CREATE TABLE Camionetas
(
	Cabina NVarchar(25) not null,
	MatriculaCamioneta NVarchar(10) not null,
	constraint FK_Camionetas_Vehiculos_MatriculaCamioneta FOREIGN KEY (MatriculaCamioneta) REFERENCES Vehiculos (Matricula) ON DELETE CASCADE,
	constraint PK_Camionetas primary key(MatriculaCamioneta)
)

CREATE TABLE Reparaciones
(
	Id integer identity (1,1) not null,
	Descripcion NVarchar(150) not null,
	Taller NVarchar(25) not null,
	Monto money not null,
	Vehiculo NVarchar(10) not null,
	constraint FK_Reparaciones_Vehiculos_Vehiculo foreign key (Vehiculo) references Vehiculos (Matricula) ON DELETE CASCADE,
	constraint PK_Reparaciones Primary Key (Id, Vehiculo)
)

CREATE TABLE Multas
(
	Id Integer identity(1,1) not null,
	Vehiculo NVarchar(10) not null,
	Suma money not null,
	Fecha date not null,
	Motivo NVarchar(150) not null,
	constraint FK_Multas_Vehiculos_Vehiculo foreign key (Vehiculo) references Vehiculos (Matricula) ON DELETE CASCADE,
	constraint PK_Multas Primary Key (Id, Vehiculo)

)

CREATE TABLE Adelantos
(
	Id integer unique identity(1,1) not null,
	Empleado integer not null,
	Suma money not null,
	CantidadCuotas int not null,
	Saldado bit not null default(0),
	constraint FK_Adelantos_Empleados_Empleado foreign key (Empleado) references Empleados (Ci) ON DELETE CASCADE,
	constraint PK_Adelantos Primary Key (Id, Empleado)

)

CREATE TABLE Cuotas
(
	Vencimiento date not null,
	IdAdelanto integer not null,
	Suma money not null,
	Pagada bit not null default(0),
	constraint FK_Cuotas_Adelantos_IdAdelanto foreign key (IdAdelanto) references Adelantos (Id) ON DELETE CASCADE,
	constraint PK_Cuotas Primary Key (Vencimiento, IdAdelanto)

)

CREATE TABLE Calificaciones
(
	Id integer identity(1,1) not null,
	Puntaje int not null,
	RutCliente bigint not null,
	Comentario NVarchar(250) not null,
	constraint FK_Calificaciones_Clientes_RutCliente foreign key (RutCliente) references Clientes (RUT) ON DELETE CASCADE,
	constraint PK_Calificaciones Primary Key (Id, RutCliente)

)

CREATE TABLE Galpones
(
	Id Integer identity(1,1) not null,
	Altura Decimal not null,
	Superficie Decimal not null,
	constraint PK_Galpones Primary Key (Id)
)

CREATE TABLE Sectores
(
	Codigo Integer not null,
	Superficie Decimal not null,
	Temperatura Integer not null,
	Galpon integer not null,
	constraint FK_Sectores_Galpones_Galpon foreign key (Galpon) references Galpones (Id) ON DELETE CASCADE,
	constraint PK_Sectores Primary Key (Codigo)
)

CREATE TABLE Racks
(
	Codigo Integer not null,
	Altura Decimal not null,
	Superficie Decimal not null,
	Sector Integer not null,
	constraint FK_Racks_Sectores_Sector foreign key (Sector) references Sectores (Codigo) ON DELETE CASCADE,
	constraint PK_Racks Primary Key (Codigo)
)

CREATE TABLE Casillas
(
	Codigo Integer not null,
	Rack Integer not null,
	constraint FK_Casillas_Racks_Rack foreign key (Rack) references Racks (Codigo) ON DELETE CASCADE,
	constraint PK_Casillas Primary Key (Codigo)
)

CREATE TABLE Palets
(
	Id Integer identity(1,1) not null,
	Producto NVarchar(100) not null,
	Cantidad Integer not null,
	Peso Decimal not null,
	Casilla Integer not null,
	Cliente bigint not null,
	constraint FK_Palets_Clientes_Cliente foreign key (Cliente) references Clientes (RUT) ON DELETE CASCADE,
	constraint FK_Palets_Casillas_Casilla foreign key (Casilla) references Casillas (Codigo) ON DELETE CASCADE,
	constraint PK_Palets Primary Key (Id)
)

CREATE TABLE Gastos
(
	Id Integer identity(1,1) not null,
	Descripcion Nvarchar(250) not null,
	Suma money not null,
	constraint PK_Gastos Primary Key (Id)
)

CREATE TABLE Impuestos
(
	Id Integer identity(1,1) not null,
	Descripcion Nvarchar(250) not null,
	Porcentaje decimal not null,
	Nombre Nvarchar(50) not null,
	constraint PK_Impuestos Primary Key (Id)
)

CREATE TABLE Ingresos
(
	Id Integer identity(1,1) not null,
	Descripcion Nvarchar(250) not null,
	Suma money not null,
	constraint PK_Ingresos Primary Key (Id)
)

CREATE TABLE Balances
(
	Id Integer identity (1,1) not null,
	Mes Nvarchar (10) not null,
	Año Integer not null,
	Abierto bit not null default(0),
	constraint PK_Balances Primary Key (Id)
)

CREATE TABLE Registros
(
	Id Integer identity (1,1) not null,
	Fecha date not null,
	UtilidadBruta money not null,
	UtilidadOperacional money not null,
	UtilidadSinImpuestos money not null,
	UtilidadEjercicio money not null,
	BalanceId integer not null,
	constraint FK_Registros_Balances_BalanceId foreign key (BalanceId) references Balances (Id) ON DELETE CASCADE,
	constraint PK_Registros Primary Key (Id)
)

CREATE TABLE Locales
(
	Id Integer identity(1,1) not null,
	Nombre Nvarchar(150) unique not null,
	Direccion Nvarchar(200) unique not null,
	constraint PK_Locales Primary Key (Id)
)

CREATE TABLE Turnos
(
	Codigo Nvarchar(7) not null,
	Dia Nvarchar(10) not null,
	Hora Integer not null,
	constraint PK_Turnos Primary Key (Codigo)
)

CREATE TABLE Entregas
(
	Codigo integer identity(1,1) not null,
	Fecha date not null,
	NombreReceptor Nvarchar(150) not null,
	ClienteReceptor bigint not null,
	ClienteEmisor bigint not null,
	LocalReceptor integer not null,
	LocalEmisor integer not null,
	Turno Nvarchar(7) not null,
	constraint FK_Entregas_Clientes_ClienteReceptor foreign key (ClienteReceptor) references Clientes  (RUT) ON DELETE CASCADE,
	constraint FK_Entregas_Clientes_ClienteEmisor foreign key (ClienteEmisor) references Clientes (RUT) ON DELETE NO ACTION,
	constraint FK_Entregas_Locales_LocalReceptor foreign key (LocalReceptor) references Locales (Id) ON DELETE CASCADE,
	constraint FK_Entregas_Locales_LocalEmisor foreign key (LocalEmisor) references Locales (Id) ON DELETE NO ACTION,
	constraint FK_Entregas_Turnos_Turno foreign key (Turno) references Turnos (Codigo) ON DELETE CASCADE,
	constraint PK_Entregas Primary Key (Codigo)
)

CREATE TABLE Paquetes
(
	NumReferencia Integer not null,
	FechaSalida date not null,
	Estado Nvarchar(15) not null,
	Ubicacion Nvarchar(100) not null,
	Entrega Integer foreign key references Entregas(Codigo),
	Cliente Bigint foreign key references Clientes(RUT),
	constraint FK_Paquetes_Entregas_Entrega foreign key (Entrega) references Entregas (Codigo) ON DELETE CASCADE,
	constraint FK_Paquetes_Clientes_Cliente foreign key (Cliente) references Clientes (RUT) ON DELETE NO ACTION,
	constraint PK_Paquetes Primary Key (NumReferencia)
)

CREATE TABLE Reclamo
(	
	Id integer identity(1,1) not null,
	Comentario Nvarchar(250) not null,
	Paquete integer foreign key references Paquetes(NumReferencia) not null,
	constraint FK_Reclamos_Paquetes_Paquete foreign key (Paquete) references Paquetes (NumReferencia) ON DELETE CASCADE,
	constraint PK_Reclamo Primary Key (Id, Paquete)
)
