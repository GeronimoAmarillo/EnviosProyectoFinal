using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaBalance
    {
        List<EntidadesCompartidasCore.Balance> ObtenerBalancesAnuales(int año);

        EntidadesCompartidasCore.Balance ObtenerBalance(string mes, int año);
    }
}
