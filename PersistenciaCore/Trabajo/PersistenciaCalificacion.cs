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
                RutCliente = calificacion.RutCliente
            };

            var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

            optionsBuilder.UseSqlServer(Conexion.ConnectionString);

            try
            {
                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Calificaciones.Add(nuevaCalificacion);
                    dbConnection.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al intentar agregar la calificacion: " + ex.Message);
            }
        }
    }
}
