﻿use EnviosContext

GO

INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Direccion, Telefono, Email)
VALUES('User1', '12345', 'Nombre1', 'Direccion1', '12345678', 'user1@dominio.com')

INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Direccion, Telefono, Email)
VALUES('User2', '12345', 'Nombre2', 'Direccion2', '12345678', 'user2@dominio.com')

INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Direccion, Telefono, Email)
VALUES('User3', '12345', 'Nombre3', 'Direccion3', '12345678', 'user3@dominio.com')

INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Direccion, Telefono, Email)
VALUES('User4', '12345', 'Nombre4', 'Direccion4', '12345678', 'user4@dominio.com')

INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Direccion, Telefono, Email)
VALUES('User5', '12345', 'Nombre5', 'Direccion5', '12345678', 'user5@dominio.com')

INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Direccion, Telefono, Email)
VALUES('User6', '12345', 'Nombre6', 'Direccion6', '12345678', 'user6@dominio.com')

INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Direccion, Telefono, Email)
VALUES('User7', '12345', 'Nombre7', 'Direccion7', '12345678', 'user7@dominio.com')




INSERT INTO Empleados (Sueldo, IdUsuario, Ci)
VALUES(15000, 1, 11111111)

INSERT INTO Empleados (Sueldo, IdUsuario, Ci)
VALUES(15000, 2, 22222222)

INSERT INTO Empleados (Sueldo, IdUsuario, Ci)
VALUES(15000, 3, 33333333)

INSERT INTO Empleados (Sueldo, IdUsuario, Ci)
VALUES(15000, 4, 44444444)

INSERT INTO Empleados (Sueldo, IdUsuario, Ci)
VALUES(15000, 5, 55555555)





INSERT INTO Administradores (CiEmpleado, Tipo)
VALUES(11111111, 'G')

INSERT INTO Administradores (CiEmpleado, Tipo)
VALUES(22222222, 'L')

INSERT INTO Administradores (CiEmpleado, Tipo)
VALUES(33333333, 'C')





INSERT INTO Cadetes(TipoLibreta, IdTelefono, CiEmpleado)
VALUES('E', 123123123, 44444444)

INSERT INTO Cadetes(TipoLibreta, IdTelefono, CiEmpleado)
VALUES('E', 321321321, 55555555)





INSERT INTO Clientes(RUT, IdUsuario, Mensualidad)
VALUES(66666666, 6, 45000)

INSERT INTO Clientes(RUT, IdUsuario, Mensualidad)
VALUES(77777777, 7, 45000)



INSERT INTO Locales(Nombre, Direccion)
VALUES('Optica1', 'DireccionOptica1')

INSERT INTO Locales(Nombre, Direccion)
VALUES('Optica2', 'DireccionOptica2')

INSERT INTO Locales(Nombre, Direccion)
VALUES('Optica3', 'DireccionOptica3')

INSERT INTO Locales(Nombre, Direccion)
VALUES('Optica4', 'DireccionOptica4')



INSERT INTO Galpones(Altura, Superficie)
VALUES(20, 1000)

INSERT INTO Sectores(Codigo, Superficie, Temperatura, Galpon)
VALUES(11, 250, 25, 1)
INSERT INTO Sectores(Codigo, Superficie, Temperatura, Galpon)
VALUES(12, 250, 20, 1)
INSERT INTO Sectores(Codigo, Superficie, Temperatura, Galpon)
VALUES(13, 250, 10, 1)
INSERT INTO Sectores(Codigo, Superficie, Temperatura, Galpon)
VALUES(14, 250, 5, 1)

INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(111, 5, 40, 11)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(112, 5, 40, 11)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(113, 5, 40, 11)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(114, 5, 40, 11)


INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(121, 5, 40, 12)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(122, 5, 40, 12)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(123, 5, 40, 12)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(124, 5, 40, 12)

INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(131, 5, 40, 13)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(132, 5, 40, 13)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(133, 5, 40, 13)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(134, 5, 40, 13)

INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(141, 5, 40, 14)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(142, 5, 40, 14)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(143, 5, 40, 14)
INSERT INTO Racks(Codigo, Altura, Superficie, Sector)
VALUES(144, 5, 40, 14)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1111, 111)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1112, 111)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1121, 112)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1122, 112)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1131, 113)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1132, 113)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1141, 114)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1142, 114)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1211, 121)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1212, 121)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1221, 122)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1222, 122)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1231, 123)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1232, 123)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1241, 124)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1242, 124)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1311, 131)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1312, 131)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1321, 132)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1322, 132)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1331, 133)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1332, 133)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1341, 134)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1342, 134)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1411, 141)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1412, 141)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1421, 142)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1422, 142)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1431, 143)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1432, 143)

INSERT INTO Casillas (Codigo, Rack)
VALUES(1441, 144)
INSERT INTO Casillas (Codigo, Rack)
VALUES(1442, 144)

INSERT INTO Gastos(Suma, Descripcion)
VALUES(1000, 'Extinsion de plagas')

INSERT INTO Gastos(Suma, Descripcion)
VALUES(1000, 'Productos de limpieza')

INSERT INTO Gastos(Suma, Descripcion)
VALUES(1000, 'Pc nueva')

INSERT INTO Gastos(Suma, Descripcion)
VALUES(1000, 'Rack nuevo')

INSERT INTO Gastos(Suma, Descripcion)
VALUES(1000, 'Despido de Jose')

INSERT INTO Impuestos(Nombre, Descripcion, Porcentaje)
VALUES('IRPF', 'Impuesto', 12)

INSERT INTO Impuestos(Nombre, Descripcion, Porcentaje)
VALUES('IVA', 'Impuesto', 20)

INSERT INTO Impuestos(Nombre, Descripcion, Porcentaje)
VALUES('BPS', 'Impuesto',8)

INSERT INTO Ingresos(Suma, Descripcion)
VALUES(1000, 'Premio IVC')

INSERT INTO Ingresos(Suma, Descripcion)
VALUES(1000, 'Inversion Envios SA')

INSERT INTO Ingresos(Suma, Descripcion)
VALUES(1000, 'Venta de camioneta')

INSERT INTO Ingresos(Suma, Descripcion)
VALUES(1000, 'Premio Anual')


INSERT INTO Vehiculos(Matricula, Marca, Modelo, Capacidad, Estado, Cadete)
VALUES('AAA1111', 'Toyota', 'Corola', 300, 'Excelente', 44444444)

INSERT INTO Vehiculos(Matricula, Marca, Modelo, Capacidad, Estado, Cadete)
VALUES('BBB2222', 'Chevrolet', 'Montana', 800, 'Nueva', 55555555)

INSERT INTO Vehiculos(Matricula, Marca, Modelo, Capacidad, Estado, Cadete)
VALUES('CCC3333', 'Yumbo', 'Shark', 30, 'Poco Desgastada', null)

INSERT INTO Vehiculos(Matricula, Marca, Modelo, Capacidad, Estado, Cadete)
VALUES('DDD4444', 'Yumbo', '4 Track', 70, 'Excelente', null)

INSERT INTO Vehiculos(Matricula, Marca, Modelo, Capacidad, Estado, Cadete)
VALUES('EEE5555', 'Jac', '1035', 1900, 'Excelente', null)

INSERT INTO Vehiculos(Matricula, Marca, Modelo, Capacidad, Estado, Cadete)
VALUES('FFF6666', 'Jac', '1040', 2200, 'Excelente', null)

INSERT INTO Automobiles(MatriculaAuto, Puertas)
VALUES('AAA1111', 4)

INSERT INTO Camionetas(MatriculaCamioneta, Cabina)
VALUES('BBB2222', 'Unica')

INSERT INTO Motos(MatriculaMoto, Cilindrada)
VALUES('CCC3333', 150)

INSERT INTO Motos(MatriculaMoto, Cilindrada)
VALUES('DDD4444', 125)

INSERT INTO Camiones(MatriculaCamion, Altura)
VALUES('EEE5555', 2.7)

INSERT INTO Camiones(MatriculaCamion, Altura)
VALUES('FFF6666', 2.5)
