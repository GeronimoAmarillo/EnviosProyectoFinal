using System;
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

        public static bool AltaLocal(EntidadesCompartidas.Locales unLocal)
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

        public static EntidadesCompartidas.Locales BuscarLocal(string nombreLocal)
        {
            EntidadesCompartidas.Locales local = new EntidadesCompartidas.Locales();
            return local;
        }

        public static EntidadesCompartidas.Locales ModificarLocal(EntidadesCompartidas.Locales unLocal)
        {
            EntidadesCompartidas.Locales local = new EntidadesCompartidas.Locales();
            return local;
        }

        public static List<EntidadesCompartidas.Locales> ListarLocales()
        {
            List<EntidadesCompartidas.Locales> lista = new List<EntidadesCompartidas.Locales>();
            return lista;
        }
    }
}
