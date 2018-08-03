using System;
using Xunit;
using EntidadesCompartidasCore;
using PersistenciaCore;
using LogicaDeServicioCore;
using System.Collections.Generic;

namespace TestsLogicaServicioCore
{
    public class LogicaUsuarioTest
    {

        [Fact]
        public void altaClienteOkTest()
        {
            Cliente unCliente = new Cliente
            {
                
                Nombre = "cliente1",
                Direccion = "Elm street 124",
                Telefono = "098574632",
                Email = "cliente1@undominio.com",
                RUT = 2547854125,
                Mensualidad = 55000
            };

            var result = LogicaUsuario.AltaUsuario(unCliente);


            Assert.True(result);
        }
        [Fact]
        public void AltaEmpleadoAdministradorOKTest()
        {
            Administrador administrador = new Administrador
            {
                Id =0,
                NombreUsuario="", 
                Contraseña="",
                Nombre="tito", 
                Direccion="direccion",
                Telefono="12345",
                Email ="email@hotmail.com",
                Sueldo =1234,
                Ci =2222222,
                Tipo ="A"
            };

            var resultado = FabricaServicio.GetControladorUsuario().AltaUsuario(administrador);

            Assert.True(resultado);

        }
        [Fact]
        public void AltaEmpleadoCadeteOKTest()
        {
            Cadete cadete = new Cadete
            {
                Id = 0,
                NombreUsuario = "",
                Contraseña = "",
                Nombre = "Matias",
                Direccion = "direccion",
                Telefono = "12345",
                Email = "email@email.com",
                Sueldo = 1234,
                Ci = 41739143,
                TipoLibreta ="a",
                IdTelefono=2345,
            };

            var resultado = FabricaServicio.GetControladorUsuario().AltaUsuario(cadete);

            Assert.True(resultado);

        }

        [Fact]
        public void altaClienteDuplicadoTest()
        {
            Cliente unCliente = new Cliente
            {

                Nombre = "cliente1",
                Direccion = "Elm street 124",
                Telefono = "098574632",
                Email = "cliente1@undominio.com",
                RUT = 2547854125,
                Mensualidad = 55000
            };

            var result = LogicaUsuario.AltaUsuario(unCliente);

            Assert.False(result);
        }
    }
}
