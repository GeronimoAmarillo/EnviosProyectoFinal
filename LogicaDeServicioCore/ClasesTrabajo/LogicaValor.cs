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

        public List<Ingreso> ListarIngresos()
        {
            List<Ingreso> ingresos = new List<Ingreso>();
            return ingresos;
        }

        public bool RegistrarIngreso(Ingreso unIngreso)
        {
            bool exito = false;
            return exito;
        }

        public bool RegistrarImpuesto(Impuesto unImpuesto)
        {
            bool exito = false;
            return exito;
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
