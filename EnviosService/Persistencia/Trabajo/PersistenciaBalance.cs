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
        public List<Balances> ObtenerBalancesAnuales(int año)
        {
            return new List<Balances>();
        }
        public Balances ObtenerBalance(string mes, int año)
        {
            return new Balances();
        }

    }
}
