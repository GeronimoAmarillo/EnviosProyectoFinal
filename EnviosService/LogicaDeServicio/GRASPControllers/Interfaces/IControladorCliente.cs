using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorCliente
    {
        bool ExisteCliente(int rut);

        Clientes BuscarCliente(int rut);

        bool ModificarCliente(Clientes pCliente);

        bool AltaCliente(Clientes pCliente);
    }
}
