using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Persistencia;

namespace LogicaDeServicioCore
{
    public class LogicaLocal
    {

        public static bool AltaLocal(EntidadesCompartidasCore.Local unLocal)
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

        public static EntidadesCompartidasCore.Local BuscarLocal(string nombreLocal)
        {
            EntidadesCompartidasCore.Local local = new EntidadesCompartidasCore.Local();
            return local;
        }

        public static EntidadesCompartidasCore.Local ModificarLocal(EntidadesCompartidasCore.Local unLocal)
        {
            EntidadesCompartidasCore.Local local = new EntidadesCompartidasCore.Local();
            return local;
        }

        public static List<Local> ListarLocales()
        {
            try
            {
                List<Local> lista = FabricaPersistencia.GetPersistenciaLocal().ListarLocales();

                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Local." + ex.Message);
            }
        }
    }
}
