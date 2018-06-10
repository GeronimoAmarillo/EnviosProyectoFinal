using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaCalificacion:IPersistenciaCalificacion
    {
        public bool Calificar(int puntaje, string comentario, EntidadesCompartidasCore.Cliente cliente)
        {
            return true;
        }
    }
}
