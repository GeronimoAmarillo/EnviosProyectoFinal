using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaCalificacion:IPersistenciaCalificacion
    {
        public bool Calificar(Calificacion calificacion)
        {
            Calificaciones nuevaCalificacion = new Calificaciones()
            {
                Puntaje = calificacion.Puntaje,
                Comentario = calificacion.Comentario,
                RutCliente = calificacion.RutCliente,
                Id = 0            };

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    Clientes cliente = dbConnection.Clientes.FirstOrDefault(x => x.RUT == calificacion.RutCliente);

                    if (cliente != null)
                    {
                        dbConnection.Calificaciones.Add(nuevaCalificacion);
                        dbConnection.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new Exception("No existe el cliente que califica.");
                    }
                    
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar agregar la calificacion: " + ex.Message);
            }
        }

        public List<EntidadesCompartidasCore.Calificacion> ListarCalificaciones()
        {
            try
            {
                List<Calificaciones> calificaciones = new List<Calificaciones>();


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);

                using (var dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    calificaciones = dbConnection.Calificaciones.ToList();
                }

                List<Calificacion> calificacionesResultado = new List<Calificacion>();

                foreach (Calificaciones l in calificaciones)
                {
                    Calificacion calificacionR = new Calificacion();

                    calificacionR.Id = l.Id;
                    calificacionR.Comentario = l.Comentario;
                    calificacionR.Puntaje = l.Puntaje;
                    calificacionR.Clientes = FabricaPersistencia.GetPersistenciaCliente().BuscarCliente(Convert.ToInt32(calificacionR.RutCliente));

                    calificacionesResultado.Add(calificacionR);
                }

                return calificacionesResultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las calificaciones." + ex.Message);
            }
        }
    }
}
