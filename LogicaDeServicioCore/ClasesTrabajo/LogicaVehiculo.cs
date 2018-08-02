using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
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

        public static bool ModificarVehiculo(Vehiculo unVehiculo)
        {
            bool exito = false;
            if (unVehiculo is Automobil)
            {
                exito = FabricaPersistencia.GetPersistenciaAuto().ModificarAuto((Automobil)unVehiculo);
            }
            if (unVehiculo is Camion)
            {
                exito = FabricaPersistencia.GetPersistenciaCamion().ModificarCamion((Camion)unVehiculo);
            }
            if (unVehiculo is Camioneta)
            {
                exito = FabricaPersistencia.GetPersistenciaCamioneta().ModificarCamioneta((Camioneta)unVehiculo);
            }
            else
            {
                exito = FabricaPersistencia.GetPersistenciaMoto().ModificarMoto((Moto)unVehiculo);
            }
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
