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
        public void loginOkTest()
        {
            string user = "User1";
            string pass = "12345";


            var result = LogicaUsuario.Login(user, pass);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (Usuarios));
            
        }

        [TestMethod]
        public void loginERRORTest()
        {
            string user = "User0";
            string pass = "12345";


            var result = LogicaUsuario.Login(user, pass);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Usuarios));

        }

        [TestMethod]
        public void buscarEmpleadoTest()
        {
            int ci = 12345677;

            var result = LogicaUsuario.BuscarEmpleado(ci);

            Assert.IsNull(result);
            
        }
    }
}
