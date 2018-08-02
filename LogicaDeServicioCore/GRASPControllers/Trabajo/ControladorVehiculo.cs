using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorVehiculo:IControladorVehiculo
    {
        public List<Cadete> ListarCadetesDisponibles()
        {
            return new List<Cadete>();
        }

        public bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            try
            {
                return LogicaVehiculo.ModificarVehiculo(pVehiculo);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Cadete SeleccionarCadete(int ci)
        {
            return new Cadete();
        }

        public Cadete BuscarEmpleado(int ci)
        {
            return new Cadete();
        }

        public bool BajaVehiculo(Vehiculo vehiculo)
        {
            return true;
        }

        public Vehiculo BuscarVehiculo(string matricula)
        {
            return new Vehiculo();
        }

        public bool AltaVehiculo(Vehiculo pVehiculo)
        {
            return true;
        }

        public bool ExisteVehiculo(string matricula)
        {
            return true;
        }
    }
}
