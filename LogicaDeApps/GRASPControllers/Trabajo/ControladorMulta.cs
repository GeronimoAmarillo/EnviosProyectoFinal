using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorMulta:IControladorMulta
    {
        private List<Vehiculo> vehiculos;
        private Multa multa;

        public void IniciarRegistroMulta()
        {

        }

        public List<DTVehiculo> ListarVehiculos()
        {
            return new List<DTVehiculo>();
        }

        public DTVehiculo SeleccionarVehiculo(string matricula)
        {
            return new DTVehiculo();
        }

        public Multa GetMulta()
        {
            return multa;
        }

        public void SetMulta(Multa pMulta)
        {
            multa = pMulta;
        }

        public void SetVehiculo(Vehiculo pVehiculo)
        {
            multa.Vehiculos = pVehiculo;
        }

        public List<Vehiculo> GetVehiculos()
        {
            return vehiculos;
        }

        public bool RegistrarMulta(DTMulta pMulta)
        {
            return true;
        }
    }
}
