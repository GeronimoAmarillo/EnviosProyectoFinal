using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaPalet
    {
        public static bool AltaPalet(Palet unPalet)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaPalet().AltaPalet(unPalet);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el Palet." + ex.Message);
            }
        }

        public static bool BajaPalet(int id)
        {
            bool exito = false;
            return exito;
        }

        public static Galpon BuscarGalpon(int id)
        {
            try
            {

                return FabricaPersistencia.GetPersistenciaPalet().BuscarGalpon(id);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el galpon." + ex.Message);
            }
        }
    }
}
