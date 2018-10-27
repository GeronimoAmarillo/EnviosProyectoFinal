using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorBalance:IControladorBalance
    {
        public List<EntidadesCompartidasCore.Balance> ConsultarBalanceAnual(int año)
        {
            return new List<EntidadesCompartidasCore.Balance>();
        }

        public EntidadesCompartidasCore.Balance ConsultarBalanceMensual(string mes, int año)
        {
            return new EntidadesCompartidasCore.Balance();
        }

        public Registro ObtenerRegistro(DateTime fecha)
        {
            try
            {
                return LogicaBalance.ObtenerRegistro(fecha);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al generar el registro: " + ex.Message);
            }
        }

        public List<Registro> ObtenerRegistros(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                return LogicaBalance.ObtenerRegistros(fechaInicio, fechaFinal);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar los registro: " + ex.Message);
            }
        }

    }
}
