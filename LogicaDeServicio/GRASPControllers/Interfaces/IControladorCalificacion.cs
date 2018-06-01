using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorCalificacion
    {
        bool Calificar(int puntaje, string comentario);
    }
}
