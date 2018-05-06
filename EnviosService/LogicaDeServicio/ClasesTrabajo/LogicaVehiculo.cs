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
        public bool altaVehiculo(Vehiculos unVehiculo)
        {
            bool exito = false;
            return exito;
        }

        public bool existeVehiculo(string matricula)
        {
            bool existe = false;
            return existe;
        }

        public Vehiculos buscarVehiculo(string matricula)
        {
            Vehiculos vehiculo = new Vehiculos();
            return vehiculo;
        }

        public bool modificarVehiculo(Vehiculos unVehiculo)
        {
            bool exito = false;
            return exito;
        }

        public bool registrarReparacion(Reparaciones unaReparacion)
        {
            bool exito = false;
            return exito;
        }

        public bool registrarMulta(Multas unaMulta)
        {
            bool exito = false;
            return exito;
        }

        public bool bajaVehiculo(string matricula)
        {
            bool exito = false;
            return exito;
        }

        public List<Vehiculos> listarVehiculos()
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();
            return vehiculos;
        }
    }
}
