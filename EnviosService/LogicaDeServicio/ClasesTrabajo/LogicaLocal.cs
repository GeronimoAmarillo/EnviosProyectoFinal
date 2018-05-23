﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace LogicaDeServicio
{
    public class LogicaLocal
    {

        public static bool AltaLocal(Locales unLocal)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaLocal().AltaLocal(unLocal);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }

        public static bool ExisteLocal(string direccion, string nombre)
        {
            bool existe = false;
            return existe;
        }

        public static Locales BuscarLocal(string nombreLocal)
        {
            Locales local = new Locales();
            return local;
        }

        public static Locales ModificarLocal(Locales unLocal)
        {
            Locales local = new Locales();
            return local;
        }

        public static List<Locales> ListarLocales()
        {
            List<Locales> lista = new List<Locales>();
            return lista;
        }
    }
}
