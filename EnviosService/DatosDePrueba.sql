use EnviosContext

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



