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

        [Fact]
        public void modificarClienteTest()
        {
            Cliente unCliente = new Cliente
            {
                Nombre = "cliente1",
                Direccion = "Elm street 124",
                Telefono = "098574632",
                Email = "cliente1@undominio.com",
                RUT = 2547854125,
                Mensualidad = 58000
            };

            var result = LogicaUsuario.ModificarUsuario(unCliente);
            Assert.True(result);
        }
    }
}
