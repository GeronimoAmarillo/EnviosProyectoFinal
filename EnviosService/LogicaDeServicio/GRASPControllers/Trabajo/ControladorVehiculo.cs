using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorVehiculo:IControladorVehiculo
    {
        public List<Cadetes> ListarCadetesDisponibles()
        {
            return new List<Cadetes>();
        }

        public bool ModificarVehiculo(Vehiculos pVehiculo)
        {
            return true;
        }

        public Cadetes SeleccionarCadete(int ci)
        {
            return new Cadetes();
        }

        public Cadetes BuscarEmpleado(int ci)
        {
            return new Cadetes();
        }

        public bool BajaVehiculo(Vehiculos vehiculo)
        {
            return true;
        }

        public Vehiculos BuscarVehiculo(string matricula)
        {
            return new Vehiculos();
        }

        public bool AltaVehiculo(Vehiculos pVehiculo)
        {
            return true;
        }

        public bool ExisteVehiculo(string matricula)
        {
            return true;
        }
    }
}
