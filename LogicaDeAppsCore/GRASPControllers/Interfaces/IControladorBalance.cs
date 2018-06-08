using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorBalance
    {
        List<Balance> ConsultarBalanceAnual(int año);

        Balance ConsultarBalanceMensual(string mes, int año);

        List<Registro> ConsultarRegistros(string mes, int año);
    }
}
