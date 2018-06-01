using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaBalance:IPersistenciaBalance
    {
        public List<EntidadesCompartidas.Balance> ObtenerBalancesAnuales(int año)
        {
            return new List<EntidadesCompartidas.Balance>();
        }
        public EntidadesCompartidas.Balance ObtenerBalance(string mes, int año)
        {
            return new EntidadesCompartidas.Balance();
        }

    }
}
