using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaCalificacion
    {
        public static bool Calificar(Calificacion cal)
        {
            
            try
            {
                bool exito = false;
                exito = FabricaPersistencia.GetPersistenciaCalificacion().Calificar(cal);
                return exito;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la calificacion." + ex.Message);
            }
        }
    }
}
