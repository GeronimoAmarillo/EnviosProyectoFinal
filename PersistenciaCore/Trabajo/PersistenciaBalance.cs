using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaBalance:IPersistenciaBalance
    {
        public List<EntidadesCompartidasCore.Balance> ObtenerBalancesAnuales(int año)
        {
            return new List<EntidadesCompartidasCore.Balance>();
        }
        public EntidadesCompartidasCore.Balance ObtenerBalance(string mes, int año)
        {
            return new EntidadesCompartidasCore.Balance();
        }

    }
}
