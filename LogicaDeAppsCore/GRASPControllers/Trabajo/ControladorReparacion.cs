using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
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

        public void IniciarRegistroReparacion()
        {

        }
    }
}
