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
        public bool Entregar(List<Entrega> entregasSeleccionadas)
        {
            bool exito = false;
            return exito;
        }

        public List<Entrega> ListarEntregas()
        {
            List<Entrega> entregas = new List<Entrega>();
            return entregas;
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

        public static bool AltaEntega(Entrega unaEntrega)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaEntrega().AltaEntrega(unaEntrega);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta la entrega." + ex);
            }
        }
    }
}
