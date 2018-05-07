using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorBalance
    {
        List<DTBalance> ConsultarBalanceAnual(int año);

        DTBalance ConsultarBalanceMensual(string mes, int año);

        List<DTRegistro> ConsultarRegistros(string mes, int año);
    }
}
