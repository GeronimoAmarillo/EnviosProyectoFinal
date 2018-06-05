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

        public static bool AltaLocal(EntidadesCompartidas.Local unLocal)
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

        public static EntidadesCompartidas.Local BuscarLocal(string nombreLocal)
        {
            EntidadesCompartidas.Local local = new EntidadesCompartidas.Local();
            return local;
        }

        public static EntidadesCompartidas.Local ModificarLocal(EntidadesCompartidas.Local unLocal)
        {
            EntidadesCompartidas.Local local = new EntidadesCompartidas.Local();
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
