using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorBalance
    {
        List<Balance> ConsultarBalanceAnual(int año);

        Balance ConsultarBalanceMensual(string mes, int año);
    }
}
