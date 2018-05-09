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
        public bool RegistrarReparacion(Reparaciones reparacion)
        {
            return true;
        }

        public List<Vehiculos> ListarVehiculos()
        {
            return new List<Vehiculos>();
        }

        public Vehiculos SeleccionarVehiculo(string matricula)
        {
            return new Vehiculos();
        }
    }
}
