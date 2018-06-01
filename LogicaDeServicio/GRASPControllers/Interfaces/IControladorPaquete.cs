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

        Paquete BuscarPaquete(int codigo);

        List<Local> ListarLocales();

        List<Paquete> ListarPaquetesEnviadosXCliente(int cedula);

        List<Paquete> ListarPaquetesRecibidosXCliente(int cedula);

        Local BuscarLocal(string nombre);
    }
}
