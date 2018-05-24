using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesCompartidas;
using LogicaDeServicio;
using Persistencia;

namespace LogicaDeServicioTests
{
    [TestClass]
    public class ControladorLocalTest
    {
        [TestMethod]
        public void AltaLocalOKTest()
        {
            EntidadesCompartidas.Local local = new EntidadesCompartidas.Local
            {
                Id = 0,
                Direccion = "DireccionOptica5",
                Nombre = "Optica5",
                Entregas = null,
                Entregas1 = null
            };

            var resultado = FabricaServicio.GetControladorLocal().AltaLocal(local);

            Assert.IsTrue(resultado);
            
        }

        [TestMethod]
        public void AltaLocalERRORTest()
        {
            EntidadesCompartidas.Local local = new EntidadesCompartidas.Local
            {
                Id = 0,
                Direccion = "DireccionOptica5",
                Nombre = "Optica5",
                Entregas = null,
                Entregas1 = null
            };

            var resultado = FabricaServicio.GetControladorLocal().AltaLocal(local);

            Assert.IsFalse(resultado);

        }
    }
}
