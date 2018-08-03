using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaCalificacion
    {
        public static bool Calificar(int puntaje, string comentario, long rutCliente)
        {
            bool exito = false;
            Calificacion nuevaCalificacion = new Calificacion()
            {
                Puntaje = puntaje,
                Comentario = comentario,
                RutCliente = rutCliente
            };
            exito = FabricaPersistencia.GetPersistenciaCalificacion().Calificar(nuevaCalificacion);
            return exito;
        }
    }
}
