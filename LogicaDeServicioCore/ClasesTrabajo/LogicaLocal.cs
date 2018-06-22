using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;
using PersistenciaCore;

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
            catch(Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Local." + ex.Message);
            }
        }

        public static bool ExisteLocal(string direccion, string nombre)
        {
            try
            {

                return FabricaPersistencia.GetPersistenciaLocal().ExisteLocal(nombre, direccion);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados." + ex.Message);
            }
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
                throw new Exception("Error al listar los locales." + ex.Message);
            }
        }
    }
}
