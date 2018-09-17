using System;
using Xunit;
using EntidadesCompartidasCore;
using PersistenciaCore;
using LogicaDeServicioCore;
using System.Collections.Generic;

namespace TestsLogicaServicioCore
{
    public class LogicaMultasTest
    {
        [Fact]
        public void RegistrarMultaOkTest()
        {
            Multa unaMulta = new Multa()
            {
                Id = 12421,
                Motivo = "test",
                Suma = 1000,
                Vehiculo = "nfa2274", //tiene que existir este vehiculo para que el test funcione!!!!
                Fecha = DateTime.Parse("2018-09-03T00:00:00")
            };

            var resultado = FabricaServicio.GetControladorMulta().RegistrarMulta(unaMulta);
            Assert.True(resultado);
        }

        [Fact]
        public void RegistrarMultaVehiculoErroneo()
        {
            Multa unaMulta = new Multa()
            {
                Id = 12421,
                Motivo = "test",
                Suma = 1000,
                Vehiculo = "vehiculoErroneo", // NO tiene que existir este vehiculo para que el test funcione!!!!
                Fecha = DateTime.Parse("2018-09-03T00:00:00")
            };

            var resultado = FabricaServicio.GetControladorMulta().RegistrarMulta(unaMulta);
            Assert.False(resultado);
        }
    }
}
