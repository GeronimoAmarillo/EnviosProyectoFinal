using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaMulta
    {
        public static bool RegistrarMulta(Multa multa)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaMulta().RegistrarMulta(multa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta la multa." + ex.Message);
            }
        }
    }
}
