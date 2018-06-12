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
                Nombre = "empleado1",
                Direccion = "Elm street 124",
                Telefono = "098574632",
                Email = "empleado1@undominio.com",
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
                Nombre = "empleado1",
                Direccion = "Elm street 124",
                Telefono = "098574632",
                Email = "empleado1@undominio.com",
                CiEmpleado = 4173914,
                Tipo = "Administrador"
            };

            var resultado = FabricaServicio.GetControladorUsuario().AltaUsuario(administrador);

            Assert.True(resultado);

        }
        [Fact]
        public void AltaEmpleadoCadeteOKTest()
        {
            Cadete cadete = new Cadete
            {
                Nombre = "cadete1",
                Direccion = "alguna 124",
                Telefono = "098574555",
                Email = "cadete1@undominio.com",
                CiEmpleado = 4173916,
                TipoLibreta="a",
                IdTelefono=2345,
            };

            var resultado = FabricaServicio.GetControladorUsuario().AltaUsuario(cadete);

            Assert.True(resultado);

        }
    }
}
