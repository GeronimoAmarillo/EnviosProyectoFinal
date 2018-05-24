﻿using System;
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
            EntidadesCompartidas.Locales local = new EntidadesCompartidas.Locales
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
            EntidadesCompartidas.Locales local = new EntidadesCompartidas.Locales
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
