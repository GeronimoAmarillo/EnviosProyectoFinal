using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorCalificacion:IControladorCalificacion
    {
        public bool Calificar(Calificacion cal)
        {
            try
            {
                return LogicaCalificacion.Calificar(cal);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la calificacion." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Calificacion> ListarCalificaciones()
        {
            try
            {
                return LogicaCalificacion.ListarCalificaciones();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la calificacion." + ex.Message);
            }
        }
    }
}
