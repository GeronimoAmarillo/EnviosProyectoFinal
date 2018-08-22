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

        public static List<Cadete> ListarCadetesDisponibles()
        {
            try
            {
                List<Cadete> lista = FabricaPersistencia.GetPersistenciaCadete().ListarCadetesDisponibles();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los cadetes disponibles." + ex.Message);
            }
        }

        public static bool AltaVehiculo(Vehiculo unVehiculo)
        {
            try
            {
                if (unVehiculo is Automobil)
                {
                    return FabricaPersistencia.GetPersistenciaAuto().AltaAuto((Automobil)unVehiculo);
                }
                else if (unVehiculo is Camion)
                {
                    return FabricaPersistencia.GetPersistenciaCamion().AltaCamion((Camion)unVehiculo);
                }
                else if (unVehiculo is Camioneta)
                {
                    return FabricaPersistencia.GetPersistenciaCamioneta().AltaCamioneta((Camioneta)unVehiculo);
                }
                else
                {
                    return FabricaPersistencia.GetPersistenciaMoto().AltaMoto((Moto)unVehiculo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Vehiculo." + ex.Message);
            }
        }

        public static bool ExisteVehiculo(string matricula)
        {
            try
            {
                bool existe = false;

                if (FabricaPersistencia.GetPersistenciaAuto().ExisteAuto(matricula))
                {
                    existe = true;
                }
                else if (FabricaPersistencia.GetPersistenciaCamion().ExisteCamion(matricula))
                {
                    existe = true;
                }
                else if (FabricaPersistencia.GetPersistenciaCamioneta().ExisteCamioneta(matricula))
                {
                    existe = true;
                }
                else if (FabricaPersistencia.GetPersistenciaMoto().ExisteMoto(matricula))
                {
                    existe = true;
                }

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del vehiculo con los datos ingresados.");
            }
        }

        public static Vehiculo BuscarVehiculo(string matricula)
        {
            try
            {
                Vehiculo vehiculo = FabricaPersistencia.GetPersistenciaAuto().BuscarAuto(matricula);

                if (vehiculo == null)
                {
                    vehiculo = FabricaPersistencia.GetPersistenciaCamioneta().BuscarCamioneta(matricula);
                }

                if (vehiculo == null)
                {
                    vehiculo = FabricaPersistencia.GetPersistenciaCamion().BuscarCamion(matricula);
                }

                if (vehiculo == null)
                {
                    vehiculo = FabricaPersistencia.GetPersistenciaMoto().BuscarMoto(matricula);
                }

                return vehiculo;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el vehiculo." + ex.Message);
            }
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

        public static bool BajaVehiculo(string matricula)
        {
            try
            {
                bool resultado = false;

                resultado = FabricaPersistencia.GetPersistenciaAuto().BajaAuto(matricula);

                if (resultado == false)
                {
                    resultado = FabricaPersistencia.GetPersistenciaCamion().BajaCamion(matricula);
                }

                if (resultado == false)
                {
                    resultado = FabricaPersistencia.GetPersistenciaCamioneta().BajaCamioneta(matricula);
                }

                if (resultado == false)
                {
                    resultado = FabricaPersistencia.GetPersistenciaMoto().BajaMoto(matricula);
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de baja el Vehiculo." + ex.Message);
            }
        }

        public static List<Vehiculo> ListarVehiculos()
        {
            try
            {
                List<Vehiculo> lista = new List<Vehiculo>();

                List<Automobil> autos = FabricaPersistencia.GetPersistenciaAuto().ListarAutos();

                lista.AddRange(autos);

                List<Camioneta> camionetas = FabricaPersistencia.GetPersistenciaCamioneta().ListarCamionetas();

                lista.AddRange(camionetas);

                List<Camion> camiones = FabricaPersistencia.GetPersistenciaCamion().ListarCamiones();

                lista.AddRange(camiones);

                List<Moto> motos = FabricaPersistencia.GetPersistenciaMoto().ListarMotos();

                lista.AddRange(motos);

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los vehiculos." + ex.Message);
            }
        }
    }
}
