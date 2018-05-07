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
        public bool AltaVehiculo(Vehiculos unVehiculo)
        {
            bool exito = false;
            return exito;
        }

        public bool ExisteVehiculo(string matricula)
        {
            bool existe = false;
            return existe;
        }

        public Vehiculos BuscarVehiculo(string matricula)
        {
            Vehiculos vehiculo = new Vehiculos();
            return vehiculo;
        }

        public bool ModificarVehiculo(Vehiculos unVehiculo)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarReparacion(Reparaciones unaReparacion)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarMulta(Multas unaMulta)
        {
            bool exito = false;
            return exito;
        }

        public bool BajaVehiculo(string matricula)
        {
            bool exito = false;
            return exito;
        }

        public List<Vehiculos> ListarVehiculos()
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();
            return vehiculos;
        }
    }
}
