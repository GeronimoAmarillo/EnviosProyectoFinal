using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorMulta:IControladorMulta
    {
        private List<Vehiculo> vehiculos;
        private Multa multa;

        public void IniciarRegistroMulta()
        {

        }

        public List<Vehiculo> ListarVehiculos()
        {
            return new List<Vehiculo>();
        }

        public Vehiculo SeleccionarVehiculo(string matricula)
        {
            return new Vehiculo();
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

        public bool RegistrarMulta(Multa pMulta)
        {
            return true;
        }
    }
}
