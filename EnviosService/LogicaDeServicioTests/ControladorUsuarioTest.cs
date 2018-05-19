using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EntidadesCompartidas;
using LogicaDeServicio;
using Persistencia;

namespace LogicaDeServicioTests
{
    [TestClass]
    public class ControladorUsuarioTest
    {
        [TestMethod]
        public void loginTest()
        {
            string user = "pepito";
            string pass = "pass123";


            var result = LogicaUsuario.Login(user, pass);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (Usuarios));
            
        }

        [TestMethod]
        public void buscarEmpleadoTest()
        {
            int ci = 12345677;

            var result = LogicaUsuario.BuscarEmpleado(ci);

            Assert.IsNull(result);
            
        }

        [TestMethod]
        public void altaClienteOkTest()
        {
            Clientes unCliente = new Clientes
            {
                Nombre = "empleado1",
                Direccion = "Elm street 124",
                Telefono = "098574632",
                Email = "empleado1@undominio.com",
                RUT = 2547854125,
                Mensualidad = 55000
            };

            var result = LogicaUsuario.AltaUsuario(unCliente);


            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}
