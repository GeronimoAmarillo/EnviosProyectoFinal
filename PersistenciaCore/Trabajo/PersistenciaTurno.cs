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
                    var turno = dbConnection.Turnos.Where(l => l.Dia == dia && l.Hora == int.Parse(hora)).Select(c => new {
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
            return new List<EntidadesCompartidasCore.Turno>();
        }

        public bool ModificarTurno(EntidadesCompartidasCore.Turno turno)
        {
            return true;
        }

        public bool AltaTurno(EntidadesCompartidasCore.Turno turno)
        {
            try
            {
                PersistenciaCore.Turnos turnoNuevo = new PersistenciaCore.Turnos();

                turnoNuevo.Dia = turno.Dia;
                turnoNuevo.Codigo = turno.Codigo;
                turnoNuevo.Hora = turno.Hora;
              

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
    }
}
