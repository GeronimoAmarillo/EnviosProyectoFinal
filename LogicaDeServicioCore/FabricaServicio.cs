using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeServicioCore
{
    public class FabricaServicio
    {

        public static IControladorAdelanto GetControladorAdelanto()
        {
            return new ControladorAdelanto();
        }

        public static IControladorBalance GetControladorBalance()
        {
            return new ControladorBalance();
        }

        public static IControladorCalificacion GetControladorCalificacion()
        {
            return new ControladorCalificacion();
        }

        public static IControladorCliente GetControladorCliente()
        {
            return new ControladorCliente();
        }

        public static IControladorEmpleado GetControladorEmpleado()
        {
            return new ControladorEmpleado();
        }

        public static IControladorEntrega GetControladorEntrega()
        {
            return new ControladorEntrega();
        }

        public static IControladorLocal GetControladorLocal()
        {
            return new ControladorLocal();
        }

        public static IControladorMulta GetControladorMulta()
        {
            return new ControladorMulta();
        }

        public static IControladorPalet GetControladorPalet()
        {
            return new ControladorPalet();
        }

        public static IControladorPaquete GetControladorPaquete()
        {
            return new ControladorPaquete();
        }

        public static IControladorReparacion GetControladorReparacion()
        {
            return new ControladorReparacion();
        }

        public static IControladorTurno GetControladorTurno()
        {
            return new ControladorTurno();
        }

        public static IControladorUsuario GetControladorUsuario()
        {
            return new ControladorUsuario();
        }

        public static IControladorVehiculo GetControladorVehiculo()
        {
            return new ControladorVehiculo();
        }
        public static IControladorValores GetControladorValores()
        {
            return new ControladorValores();
        }
    }
}
