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
            Locales local = new Locales
            {
                Id = 0,
                Direccion = "Calle 25 Santa Ana",
                Nombre = "Optica Oculio",
                Entregas = null,
                Entregas1 = null
            };

            var resultado = FabricaServicio.GetControladorLocal().AltaLocal(local);

            Assert.IsTrue(resultado);
            
        }

        [TestMethod]
        public void AltaLocalERRORTest()
        {
            Locales local = new Locales
            {
                Id = 0,
                Direccion = "Calle 25 Santa Anaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Nombre = "Optica Oculiasfassdasdsaaasasfsssssssssasasasao",
                Entregas = null,
                Entregas1 = null
            };

            var resultado = FabricaServicio.GetControladorLocal().AltaLocal(local);

            Assert.IsTrue(resultado);

        }
    }
}
