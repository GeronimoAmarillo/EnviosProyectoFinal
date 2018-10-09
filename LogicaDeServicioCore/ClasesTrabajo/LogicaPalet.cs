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
            try
            {
                return FabricaPersistencia.GetPersistenciaPalet().BajaPalet(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de baja el Palet." + ex.Message);
            }
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

        public static Palet BuscarPalet(int id)
        {
            try
            {

                return FabricaPersistencia.GetPersistenciaPalet().BuscarPalet(id);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el palet." + ex.Message);
            }
        }

        public static List<Palet> ListarPalets()
        {
            try
            {

                return FabricaPersistencia.GetPersistenciaPalet().ListarPalets();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los palets." + ex.Message);
            }
        }
    }
}
