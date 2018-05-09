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
        public List<Vehiculos> ListarVehiculos()
        {
            return new List<Vehiculos>();
        }

        public Vehiculos SeleccionarVehiculo(string matricula)
        {
            return new Vehiculos();
        }

        public bool RegistrarMulta(Multas pMulta)
        {
            return true;
        }
    }
}
