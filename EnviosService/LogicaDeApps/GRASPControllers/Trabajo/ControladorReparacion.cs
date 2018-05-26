using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorReparacion : IControladorReparacion
    {
        private Reparacion reparacion;

        public Reparacion GetReparacion()
        {
            return reparacion;
        }

        public void SetReparacion(Reparacion pReparacion)
        {
            reparacion = pReparacion;
        }

        public bool RegistrarReparacion(DTReparacion reparacion)
        {
            return true;
        }

        public List<DTVehiculo> ListarVehiculos()
        {
            return new List<DTVehiculo>();
        }

        public DTVehiculo SeleccionarVehiculo(string matricula)
        {
            return new DTVehiculo();
        }

        public void IniciarRegistroReparacion()
        {

        }
    }
}
