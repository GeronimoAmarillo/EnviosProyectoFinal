using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorCliente
    {
        bool ExisteCliente(int rut);

        void IniciarRegistroCliente();

        Clientes GetCliente();

        DTCliente BuscarCliente(int rut);

        bool ModificarCliente(DTCliente pCliente);

        void SetCliente(Clientes pCliente);

        bool RegistrarCliente(DTCliente pCliente);
    }
}
