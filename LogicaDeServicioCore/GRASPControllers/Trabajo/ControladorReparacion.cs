using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorReparacion:IControladorReparacion
    {
        public bool RegistrarReparacion(Reparacion reparacion)
        {
            try
            {
                return LogicaVehiculo.RegistrarReparacion(reparacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar registrar la reparación." + ex.Message);
            }
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

        public Vehiculo SeleccionarVehiculo(string matricula)
        {
            try
            {
                return LogicaVehiculo.BuscarVehiculo(matricula);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el vehiculo.");
            }
        }
    }
}
