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
        public void loginOKTest()
        {
            string user = "User1";
            string pass = "12345";


            var result = LogicaUsuario.Login(user, pass);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof (EntidadesCompartidas.Usuario));
            
        }


        [TestMethod]
        public void loginERRORTest()
        {
            string user = "User8";
            string pass = "12345";


            var result = LogicaUsuario.Login(user, pass);

            Assert.IsNull(result);

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
