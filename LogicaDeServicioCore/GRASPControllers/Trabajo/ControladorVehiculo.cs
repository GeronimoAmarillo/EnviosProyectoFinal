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

        public List<Vehiculo> ListarVehiculos()
        {
            try
            {
                return LogicaVehiculo.ListarVehiculos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los vehiculos." + ex.Message);
            }
        }

        public bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            return true;
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
            try
            {
                return LogicaVehiculo.AltaVehiculo(pVehiculo);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Vehiculo.");
            }
        }

        public bool ExisteVehiculo(string matricula)
        {
            try
            {
                return LogicaVehiculo.ExisteVehiculo(matricula);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Vehiculo con los datos ingresados.");
            }
        }
    }
}
