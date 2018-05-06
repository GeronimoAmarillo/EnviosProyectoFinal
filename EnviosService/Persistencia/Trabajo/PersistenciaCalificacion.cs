using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaCalificacion:IPersistenciaCalificacion
    {
        public bool Calificar(int puntaje, string comentario, Clientes cliente)
        {
            return true;
        }
    }
}
