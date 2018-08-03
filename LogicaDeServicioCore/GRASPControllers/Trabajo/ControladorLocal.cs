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
    class ControladorLocal:IControladorLocal
    {
        public bool ExisteLocal(string nombre, string direccion)
        {
            try
            {
                return LogicaLocal.ExisteLocal(direccion, nombre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
        }

        public EntidadesCompartidasCore.Local BuscarLocal(int id)
        {
            try
            {
                return LogicaLocal.BuscarLocal(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el local.");
            }
        }

        public bool ModificarLocal(EntidadesCompartidasCore.Local local)
        {
            try
            {
                return LogicaLocal.ModificarLocal(local);
            }
            catch
            {
                throw new Exception("Error al intentar modificar el Local.");
            }
        }

        public bool AltaLocal(EntidadesCompartidasCore.Local local)
        {
            try
            {
                return LogicaLocal.AltaLocal(local);
            }
            catch
            {
                throw new Exception("Error al intentar dar de alta el Local.");
            }
        }

        public List<Local> ListarLocales()
        {
            try
            {
                return LogicaLocal.ListarLocales();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al Listar los locales." + ex.Message);
            }
        }
    }
}
