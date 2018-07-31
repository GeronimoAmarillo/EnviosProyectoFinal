using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaAdelanto
    {
        public static bool RealizarAdelanto(Adelanto unAdelanto)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaAdelanto().RealizarAdelanto(unAdelanto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar registrar el adelanto." + ex.Message);
            }
        }

        public static List<Adelanto> ListarAdelantos()
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaAdelanto().ListarAdelantos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar listar los adelantos." + ex.Message);
            }
        }
    }
}
