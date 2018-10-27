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
        Task<List<Balance>> ConsultarBalanceAnual(int año);

        Task<Balance> ConsultarBalanceMensual(string mes, int año);

        Task<Registro> ConsultarRegistro(DateTime fecha);

        Task<List<Registro>> ConsultarRegistros(DateTime fechaInicio, DateTime fechaFinal);
    }
}
