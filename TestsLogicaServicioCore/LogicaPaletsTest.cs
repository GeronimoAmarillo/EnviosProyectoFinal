using System;
using Xunit;
using EntidadesCompartidasCore;
using PersistenciaCore;
using LogicaDeServicioCore;
using System.Collections.Generic;

namespace TestsLogicaServicioCore
{
    public class LogicaPaletsTest
    {
        public void AltaPaletOKTest()
        {
            Local local = new Local
            {
                Id = 0,
                Direccion = "DireccionOptica5",
                Nombre = "Optica5",
                Entregas = null,
                Entregas1 = null
            };

            var resultado = FabricaServicio.GetControladorLocal().AltaLocal(local);

            Assert.True(resultado);

        }

        [Fact]
        public void AltaPaletERRORTest()
        {
            Local local = new Local
            {
                Id = 0,
                Direccion = "DireccionOptica5",
                Nombre = "Optica5",
                Entregas = null,
                Entregas1 = null
            };

            var resultado = FabricaServicio.GetControladorLocal().AltaLocal(local);

            Assert.True(resultado);

        }

        [Fact]
        public void ListarPaletsTest()
        {
            Assert.IsType<List<Local>>(FabricaServicio.GetControladorLocal().ListarLocales());
        }
    }
}
