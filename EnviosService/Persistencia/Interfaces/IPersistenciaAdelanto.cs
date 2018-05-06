using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaAdelanto
    {
        bool RealizarAdelanto(Adelantos adelanto);
    }
}
