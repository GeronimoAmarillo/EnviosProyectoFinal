using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorReparacion:IControladorReparacion
    {
        public bool RegistrarReparacion(Reparacion reparacion)
        {
            return true;
        }

        public List<Vehiculo> ListarVehiculos()
        {
            return new List<Vehiculo>();
        }

        public Vehiculo SeleccionarVehiculo(string matricula)
        {
            return new Vehiculo();
        }
    }
}
