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
            try
            {
                return LogicaBalance.ObtenerBalancesAnuales(año);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el balance: " + ex.Message);
            }
        }

        public static Balance ObtenerBalanceAnual(DateTime fechaDesde, DateTime FechaHasta)
        {
            try
            {
                return LogicaBalance.ObtenerBalanceAnual(fechaDesde, FechaHasta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el balance: " + ex.Message);
            }
        }

        public EntidadesCompartidasCore.Balance ConsultarBalanceMensual(int mes, int año)
        {
            try
            {
                return LogicaBalance.BuscarBalance(mes, año);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el balance: " + ex.Message);
            }
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
