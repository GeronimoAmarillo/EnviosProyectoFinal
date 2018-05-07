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
        private List<Vehiculos> vehiculos;
        private Multas multa;

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

        public Multas GetMulta()
        {
            return multa;
        }

        public void SetMulta(Multas pMulta)
        {
            multa = pMulta;
        }

        public void SetVehiculo(Vehiculos pVehiculo)
        {
            multa.Vehiculos = pVehiculo;
        }

        public List<Vehiculos> GetVehiculos()
        {
            return vehiculos;
        }

        public bool RegistrarMulta(DTMulta pMulta)
        {
            return true;
        }
    }
}
