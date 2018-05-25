using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public class LogicaVehiculo
    {
        public bool AltaVehiculo(Vehiculo unVehiculo)
        {
            bool exito = false;
            return exito;
        }

        public bool ExisteVehiculo(string matricula)
        {
            bool existe = false;
            return existe;
        }

        public Vehiculo BuscarVehiculo(string matricula)
        {
            Vehiculo vehiculo = new Vehiculo();
            return vehiculo;
        }

        public bool ModificarVehiculo(Vehiculo unVehiculo)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarReparacion(Reparacion unaReparacion)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarMulta(Multa unaMulta)
        {
            bool exito = false;
            return exito;
        }

        public bool BajaVehiculo(string matricula)
        {
            bool exito = false;
            return exito;
        }

        public List<Vehiculo> ListarVehiculos()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            return vehiculos;
        }
    }
}
