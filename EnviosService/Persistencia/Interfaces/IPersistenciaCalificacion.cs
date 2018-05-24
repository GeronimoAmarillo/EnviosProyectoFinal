using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCalificacion
    {
        bool Calificar(int puntaje, string comentario, EntidadesCompartidas.Clientes cliente);
    }
}
