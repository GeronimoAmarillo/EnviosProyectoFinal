using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorValores
    {
        List<Gasto> ListarGastos();

        bool RegistrarIngreso(Ingreso ingreso);

        bool RegistrarImpuesto(Impuesto impuesto);

        List<Ingreso> ListarIngresos();

        bool RegistrarGasto(Gasto gasto);
    }
}
