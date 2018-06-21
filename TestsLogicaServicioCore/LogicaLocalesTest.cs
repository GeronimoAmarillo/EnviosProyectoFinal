using System;
using Xunit;
using EntidadesCompartidasCore;
using PersistenciaCore;
using LogicaDeServicioCore;
using System.Collections.Generic;

namespace TestsLogicaServicioCore
{
    public class LogicaLocalesTest
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void AltaLocalOKTest()
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
        public void AltaLocalERRORTest()
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

            Assert.False(resultado);

        }

        [Fact]
        public void ListarLocalesTest()
        {
            Assert.IsType<List<Local>>(FabricaServicio.GetControladorLocal().ListarLocales());
        }
    }
}
