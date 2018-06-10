using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaIngreso
    {
        List<EntidadesCompartidasCore.Ingreso> ListarIngresos();

        bool RegistrarIngreso(EntidadesCompartidasCore.Ingreso ingreso);
    }
}
