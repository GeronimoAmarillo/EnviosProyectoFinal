using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorPaquete
    {
        bool RealizarReclamo(string descripcion);

        Paquetes BuscarPaquete(int codigo);

        List<Locales> ListarLocales();

        List<Paquetes> ListarPaquetesEnviadosXCliente(int cedula);

        List<Paquetes> ListarPaquetesRecibidosXCliente(int cedula);

        Locales BuscarLocal(string nombre);
    }
}
