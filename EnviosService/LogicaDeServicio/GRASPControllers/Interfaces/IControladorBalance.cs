using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorBalance
    {
        List<Balance> ConsultarBalanceAnual(int año);

        Balance ConsultarBalanceMensual(string mes, int año);
    }
}
