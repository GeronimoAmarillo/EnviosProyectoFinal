using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorLocal
    {
        bool ExisteLocal(string nombre, string direccion);

        void IniciarRegistroLocal();

        DTLocal BuscarLocal(string nombre);

        bool ModificarLocal(DTLocal local);

        void SetLocal(Local pLocal);

        bool AltaLocal();
    }
}
