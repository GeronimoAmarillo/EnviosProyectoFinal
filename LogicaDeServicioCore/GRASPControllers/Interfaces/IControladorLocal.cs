using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public interface IControladorLocal
    {
        bool ExisteLocal(string nombre, string direccion);

        Local BuscarLocal(string nombre);

        bool ModificarLocal(Local local);

        bool AltaLocal(Local local);

        List<Local> ListarLocales();
    }
}
