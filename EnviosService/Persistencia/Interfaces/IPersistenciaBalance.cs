using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaBalance
    {
        List<Balances> ObtenerBalancesAnuales(int año);

        Balances ObtenerBalance(string mes, int año);
    }
}
