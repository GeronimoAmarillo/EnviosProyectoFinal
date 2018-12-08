using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidasAndroid
{
    public static class ConexionREST
    {
        //static string conexionRaiz = "http://169.254.80.80:8080/api/";
        //static string conexionLocales = "http://169.254.80.80:8080/api/Locales";
        //static string conexionPalets = "http://169.254.80.80:8080/api/Palets";
        //static string conexionUsuarios = "http://169.254.80.80:8080/api/Usuarios";
        //static string conexionVehiculos = "http://169.254.80.80:8080/api/Vehiculos";
        //static string conexionValores = "http://169.254.80.80:8080/api/Valores";
        //static string conexionClientes = "http://169.254.80.80:8080/api/Clientes";
        //static string conexionAdelantos = "http://169.254.80.80:8080/api/Adelantos";
        //static string conexionMultas = "http://169.254.80.80:8080/api/Multas";
        //static string conexionReparaciones = "http://169.254.80.80:8080/api/Reparaciones";
        //static string conexionTurnos = "http://169.254.80.80:8080/api/Turnos";
        //static string conexionEntregas = "http://169.254.80.80:8080/api/Entregas";
        //static string conexionEmpleados = "http://169.254.80.80:8080/api/Empleados";

        static string conexionRaiz = "https://enviosservice.azurewebsites.net/api/";
        static string conexionLocales = "https://enviosservice.azurewebsites.net/api/Locales";
        static string conexionPalets = "https://enviosservice.azurewebsites.net/api/Palets";
        static string conexionUsuarios = "https://enviosservice.azurewebsites.net/api/Usuarios";
        static string conexionVehiculos = "https://enviosservice.azurewebsites.net/api/Vehiculos";
        static string conexionValores = "https://enviosservice.azurewebsites.net/api/Valores";
        static string conexionClientes = "https://enviosservice.azurewebsites.net/api/Clientes";
        static string conexionAdelantos = "https://enviosservice.azurewebsites.net/api/Adelantos";
        static string conexionMultas = "https://enviosservice.azurewebsites.net/api/Multas";
        static string conexionReparaciones = "https://enviosservice.azurewebsites.net/api/Reparaciones";
        static string conexionTurnos = "https://enviosservice.azurewebsites.net/api/Turnos";
        static string conexionEntregas = "https://enviosservice.azurewebsites.net/api/Entregas";
        static string conexionEmpleados = "https://enviosservice.azurewebsites.net/api/Empleados";


        public static string ConexionValores { get => conexionValores; }
        public static string ConexionVehiculos { get => conexionVehiculos; }
        public static string ConexionUsuarios { get => conexionUsuarios; }
        public static string ConexionPalets { get => conexionPalets; }
        public static string ConexionLocales { get => conexionLocales; }
        public static string ConexionRaiz { get => conexionRaiz; }
        public static string ConexionClientes { get => conexionClientes; }
        public static string ConexionReparaciones { get => conexionReparaciones; }
        public static string ConexionMultas { get => conexionMultas; }
        public static string ConexionAdelantos { get => conexionAdelantos; }
        public static string ConexionTurnos { get => conexionTurnos; }
        public static string ConexionEntregas { get => conexionEntregas; }

        public static string ConexionEmpleados { get => conexionEmpleados; }
    }
}
