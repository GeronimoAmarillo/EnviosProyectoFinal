using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorCalificacion:IControladorCalificacion
    {
        public bool Calificar(int puntaje, string comentario, int rutCliente)
        {
            LogicaCalificacion.Calificar(puntaje, comentario, rutCliente);
            return true;
        }
    }
}
