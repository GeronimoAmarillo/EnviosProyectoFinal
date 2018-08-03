using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaValor
    {
        public static List<Gasto> ListarGastos()
        {
            try
            {
                List<Gasto> lista = FabricaPersistencia.GetPersistenciaGasto().ListarGastos();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los gastos." + ex.Message);
            }
        }

        public static List<Ingreso> ListarIngresos()
        {
            try
            {
                List<Ingreso> lista = FabricaPersistencia.GetPersistenciaIngreso().ListarIngresos();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los ingresos." + ex.Message);
            }
        }

        public static bool RegistrarIngreso(Ingreso unIngreso)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaIngreso().RegistrarIngreso(unIngreso);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el ingreso." + ex.Message);
            }
        }

        public static  bool RegistrarImpuesto(Impuesto unImpuesto)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaImpuesto().RegistrarImpuesto(unImpuesto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el impuesto." + ex.Message);
            }
        }

        public static List<Impuesto> ListarImpuestos()
        {
            try
            {
                List<Impuesto> lista = FabricaPersistencia.GetPersistenciaImpuesto().ListarImpuestos();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los impuestos." + ex.Message);
            }
        }

        public static bool RegistrarGasto(Gasto unGasto)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaGasto().RegistrarGasto(unGasto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el gasto." + ex.Message);
            }
        }
    }
}
