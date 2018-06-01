using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeApps
{
    public class FabricaApps
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

        public static IControladorConsultasPaquete GetControladorConsultasPaquete()
        {
            return new ControladorConsultasPaquete();
        }

        public static IControladorEmpleado GetControladorEmpleado()
        {
            return new ControladorEmpleado();
        }

        public static IControladorEntrega GetControladorEntrega()
        {
            return new ControladorEntrega();
        }

        public static IControladorGasto GetControladorGasto()
        {
            return new ControladorGasto();
        }

        public static IControladorImpuesto GetControladorImpuesto()
        {
            return new ControladorImpuesto();
        }

        public static IControladorIngreso GetControladorIngreso()
        {
            return new ControladorIngreso();
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

        public static IControladorRealizarEntregas GetControladorRealizarEntregas()
        {
            return new ControladorRealizarEntregas();
        }

        public static IControladorReparacion GetControladorReparacion()
        {
            return new ControladorReparacion();
        }

        public static IControladorTrackeo GetControladorTrackeo()
        {
            return new ControladorTrackeo();
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

    }
}
