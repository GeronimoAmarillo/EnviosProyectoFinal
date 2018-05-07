using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorVehiculo: IControladorVehiculo
    {
        private Vehiculos vehiculo;

        public Vehiculos GetVehiculo()
        {
            return vehiculo;
        }

        public void SetMatricula(string matricula)
        {
            vehiculo.Matricula = matricula;
        }

        public List<DTCadete> ListarCadetesDisponibles()
        {
            return new List<DTCadete>();
        }

        public Cadetes GetCadete()
        {
            return new Cadetes();
        }
    }
}
