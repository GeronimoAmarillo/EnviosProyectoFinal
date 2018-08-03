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
        [Fact]
        public void AltaPaletOKTest()
        {
            Palet palet = new Palet
            {
                Cantidad = 10,
                Casilla = 1,
                Cliente = 11111111,
                Id = 0,
                Peso = 80,
                Producto = "Arroz"
            };

            var resultado = FabricaServicio.GetControladorPalet().AltaPalet(palet);

            Assert.True(resultado);

        }

        [Fact]
        public void AltaPaletERRORTest()
        {
            Palet palet = new Palet
            {
                Cantidad = 10,
                Casilla = 1,
                Cliente = 11111111,
                Id = 0,
                Peso = 80,
                Producto = "Arroz"
            };

            var resultado = FabricaServicio.GetControladorPalet().AltaPalet(palet);

            Assert.False(resultado);

        }

        [Fact]
        public void ListarPaletsTest()
        {
            Assert.IsType<List<Local>>(FabricaServicio.GetControladorLocal().ListarLocales());
        }
    }
}
