using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorMulta:IControladorMulta
    {
        public List<Vehiculo> ListarVehiculos()
        {
            return new List<Vehiculo>();
        }

        public Vehiculo SeleccionarVehiculo(string matricula)
        {
            return new Vehiculo();
        }

        public bool RegistrarMulta(Multa pMulta)
        {
            return true;
        }
    }
}
