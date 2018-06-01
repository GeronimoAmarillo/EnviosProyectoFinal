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
        Ingreso GetIngreso();

        void SetIngreso(Ingreso pIngreso);

        bool ReigstrarIngreso(DTIngreso ingreso);

        void SetIngresos(List<Ingreso> pIngresos);

        List<Ingreso> GetIngresos();

        List<DTIngreso> ListarIngresos();
    }
}
