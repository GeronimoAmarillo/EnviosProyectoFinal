using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorCliente
    {
        bool ExisteCliente(int rut);

        Cliente BuscarCliente(int rut);

        bool ModificarCliente(Cliente pCliente);

        bool AltaCliente(Cliente pCliente);
    }
}
