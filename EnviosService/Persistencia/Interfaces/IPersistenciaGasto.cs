using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaGasto
    {
        bool RegistrarGasto(EntidadesCompartidas.Gastos gasto);

        List<EntidadesCompartidas.Gastos> ListarGastos();
    }
}
