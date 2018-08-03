using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaTurno
    {
        public static bool ExisteTurno(string dia, string hora)
        {
            try
            {

                return FabricaPersistencia.GetPersistenciaTurno().ExisteTurno( dia, hora);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Turno con los datos ingresados." + ex.Message);
            }
        }

        public Boolean ModificarTurno(Turno unTurno)
        {
            bool exito = false;
            return exito;
        }

        public static bool AltaTurno(Turno unTurno)
        {
            try
            {
                return FabricaPersistencia.GetPersistenciaTurno().AltaTurno(unTurno);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta el turno." + ex.Message);
            }
        }

        public List<Turno> ListarTurnos()
        {
            List<Turno> turnos = new List<Turno>();
            return turnos;
        }
    }
}
