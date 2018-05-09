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
        List<Gastos> ListarGastos();

        bool RegistrarIngreso(Ingresos ingreso);

        bool RegistrarImpuesto(Impuestos impuesto);

        List<Ingresos> ListarIngresos();

        bool RegistrarGasto(Gastos gasto);
    }
}
