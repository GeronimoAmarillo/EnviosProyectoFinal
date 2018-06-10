using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorLocal
    {
        Task<bool> ExisteLocal(string nombre, string direccion);

        void IniciarRegistroLocal();

        Local BuscarLocal(string nombre);

        bool ModificarLocal(Local local);

        Task<List<Local>> ListarLocales();

        void SetLocal(Local pLocal);

        Local GetLocal();

        bool AltaLocal();
    }
}
