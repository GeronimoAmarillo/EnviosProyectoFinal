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
    class ControladorTurno:IControladorTurno
    {

        public bool ExisteTurno(string dia, string hora)
        { try
            {
                return LogicaTurno.ExisteTurno(dia,hora);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar comprobar la existencia del Local con los datos ingresados.");
            }
        }

        public Turno BuscarTurno(string codigo)
        {
            try
            {
                return LogicaTurno.BuscarTurno(codigo);
            }

            catch
            {
                throw new Exception("Error al buscar el turno.");
            }
        }

        public bool ModificarTurno(Turno pTurno)
        {
            try
            {
                return LogicaTurno.ModificarTurno(pTurno);
            }

            catch
            {
                throw new Exception("Error al intentar dar de modificar el turno.");
            }
        }

        public bool AltaTurno(Turno turno)
        {
            try
            {
                return LogicaTurno.AltaTurno(turno);
            }

            catch
            {
                throw new Exception("Error al intentar dar de alta el turno.");
            }
        }

        public List<Turno> ListarTurnos()
        {
            try
            {
                return LogicaTurno.ListarTurnos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar los turnos." + ex.Message);
            }
        }
    }
}
