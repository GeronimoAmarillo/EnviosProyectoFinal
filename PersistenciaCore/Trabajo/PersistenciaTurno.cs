using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace PersistenciaCore
{
    class PersistenciaTurno:IPersistenciaTurno
    {
        public bool ExisteTurno(string dia, string hora)
        {
            try
            {
                bool existe = false;

              

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var turno = dbConnection.Turnos.Where(l => l.Dia == dia && l.Hora == int.Parse(hora) && l.Eliminado == false).Select(c => new {
                        Trn = c
                    }).FirstOrDefault();

                    if (turno != null && turno.Trn is Turnos)
                    {
                        existe = true;
                    }
                }

                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el turno." + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Turno> ListarTurnos()
        {
            try
            {
                List<Turnos> turnos = new List<Turnos>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    turnos = dbConnection.Turnos.Where(x => x.Eliminado == false).ToList();
                }

                List<Turno> turnosResultado = new List<Turno>();

                foreach (Turnos l in turnos)
                {
                    Turno turnoR = new Turno();

                    turnoR.Codigo = l.Codigo;
                    turnoR.Dia = l.Dia;
                    turnoR.Hora = l.Hora;
                    turnoR.Eliminado = l.Eliminado;

                    turnosResultado.Add(turnoR);
                }

                return turnosResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los turnos." + ex.Message);
            }
        }

        public Turnos IdentificarTurno(string diaSemana, int hora)
        {
            try
            {
                Turnos turnoCandidato = new Turnos();
                List<Turnos> turnos = new List<Turnos>();

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    turnos = dbConnection.Turnos.Where(x=> x.Dia == diaSemana).ToList();
                }

                turnos.OrderBy(x=> x.Hora);
                
                for (int t = 0; t < turnos.Count; t++)
                {
                    if (turnos[t].Hora < hora)
                    {
                        turnoCandidato = turnos[t];
                    }
                    else
                    {
                        turnoCandidato = turnos[t - 1];
                    }
                }

                return turnoCandidato;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al identificar el turno." + ex.Message);
            }
        }

        public bool EliminarTurno(EntidadesCompartidasCore.Turno turno)
        {
            try
            {
                PersistenciaCore.Turnos turnoEliminar = new PersistenciaCore.Turnos();
                turnoEliminar.Codigo = turno.Codigo;
                turnoEliminar.Dia = turno.Dia;
                turnoEliminar.Hora = turno.Hora;
                turnoEliminar.Eliminado = true;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Turnos.Update(turnoEliminar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el turno.");
            }
        }

        public bool AltaTurno(EntidadesCompartidasCore.Turno turno)
        {
            try
            {
                PersistenciaCore.Turnos turnoNuevo = new PersistenciaCore.Turnos();

                turnoNuevo.Dia = turno.Dia;
                turnoNuevo.Codigo = turno.Codigo;
                turnoNuevo.Hora = turno.Hora;
                turnoNuevo.Eliminado = false;
              

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Turnos.Add(turnoNuevo);

                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el turno.");
            }

        }
        public EntidadesCompartidasCore.Turno BuscarTurno(string codigo)
        {
            try
            {
                Turno turnoresultado = null;

                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    var turno = dbConnection.Turnos.Where(t => t.Codigo == codigo && t.Eliminado == false).Select(c => new {
                        Turno = c
                    }).FirstOrDefault();

                    if (turno != null && turno.Turno is Turnos)
                    {
                        turnoresultado = new Turno();
                        turnoresultado.Codigo = codigo;
                        turnoresultado.Dia = turno.Turno.Dia;
                        turnoresultado.Hora = turno.Turno.Hora;
                        turnoresultado.Eliminado = turno.Turno.Eliminado;
                    }
                }

                return turnoresultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el local." + ex.Message);
            }
        }

    }
}
