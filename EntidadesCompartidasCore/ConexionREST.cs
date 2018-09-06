﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidasCore
{
    public static class ConexionREST
    {
        static string conexionRaiz = "http://localhost:8080/api/";
        static string conexionLocales = "http://localhost:8080/api/Locales";
        static string conexionPalets = "http://localhost:8080/api/Palets";
        static string conexionUsuarios = "http://localhost:8080/api/Usuarios";
        static string conexionVehiculos = "http://localhost:8080/api/Vehiculos";
        static string conexionValores = "http://localhost:8080/api/Valores";
        static string conexionClientes = "http://localhost:8080/api/Clientes";
        static string conexionAdelantos = "http://localhost:8080/api/Adelantos";
        static string conexionMultas = "http://localhost:8080/api/Multas";

        public static string ConexionValores { get => conexionValores; }
        public static string ConexionVehiculos { get => conexionVehiculos; }
        public static string ConexionUsuarios { get => conexionUsuarios; }
        public static string ConexionPalets { get => conexionPalets; }
        public static string ConexionLocales { get => conexionLocales; }
        public static string ConexionRaiz { get => conexionRaiz; }
        public static string ConexionClientes { get => conexionClientes; }
        public static string ConexionMultas { get => conexionMultas; }
        public static string ConexionAdelantos { get => conexionAdelantos; }
    }
}
