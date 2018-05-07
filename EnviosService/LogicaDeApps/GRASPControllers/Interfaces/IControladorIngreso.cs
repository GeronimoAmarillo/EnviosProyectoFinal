using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorIngreso
    {
        Ingresos GetIngreso();

        void SetIngreso(Ingresos pIngreso);

        bool ReigstrarIngreso(DTIngreso ingreso);

        void SetIngresos(List<Ingresos> pIngresos);

        List<Ingresos> GetIngresos();

        List<DTIngreso> ListarIngresos();
    }
}
