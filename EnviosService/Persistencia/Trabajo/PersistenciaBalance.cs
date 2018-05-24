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
        public List<EntidadesCompartidas.Balances> ObtenerBalancesAnuales(int año)
        {
            return new List<EntidadesCompartidas.Balances>();
        }
        public EntidadesCompartidas.Balances ObtenerBalance(string mes, int año)
        {
            return new EntidadesCompartidas.Balances();
        }

    }
}
