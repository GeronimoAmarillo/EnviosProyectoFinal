using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaEntrega
    {
        public static bool Entregar(Entrega entrega)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEntrega().Entregar(entrega);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar realizar la entrega." + ex);
            }
        }

        public static List<Entrega> ListarEntregas(int cadete)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEntrega().ListarEntregas(cadete);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las entregas." + ex);
            }
        }

        public static Entrega BuscarEntrega(int codigo)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEntrega().BuscarEntrega(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la entrega." + ex.Message);
            }
        }

        public static bool AsignarEntrega(Entrega unaEntrega)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEntrega().AsignarEntrega(unaEntrega);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta la entrega." + ex);
            }
        }

        public static bool LevantarEntrega(Entrega unaEntrega)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEntrega().LevantarEntrega(unaEntrega);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta la entrega." + ex);
            }
        }
    }
}
