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
            Assert.IsInstanceOfType(result, typeof (EntidadesCompartidas.Usuario));
            
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
