using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorCalificacion
    {
        bool Calificar(Calificacion cal);
        List<EntidadesCompartidasCore.Calificacion> ListarCalificaciones();
    }
}
