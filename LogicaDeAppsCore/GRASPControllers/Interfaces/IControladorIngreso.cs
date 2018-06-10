using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorIngreso
    {
        Ingreso GetIngreso();

        void SetIngreso(Ingreso pIngreso);

        bool ReigstrarIngreso(Ingreso ingreso);

        void SetIngresos(List<Ingreso> pIngresos);

        List<Ingreso> GetIngresos();

        List<Ingreso> ListarIngresos();
    }
}
