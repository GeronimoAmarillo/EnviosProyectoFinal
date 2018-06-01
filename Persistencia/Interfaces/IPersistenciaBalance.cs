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
        List<EntidadesCompartidas.Balance> ObtenerBalancesAnuales(int año);

        EntidadesCompartidas.Balance ObtenerBalance(string mes, int año);
    }
}
