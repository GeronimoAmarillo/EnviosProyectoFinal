using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorPaquete
    {
        bool RealizarReclamo(string descripcion);

        Paquete BuscarPaquete(int numReferencia);

        Paquete BuscarPaqueteIndividual(int numReferencia, int cliente);

        List<Local> ListarLocales();

        List<Paquete> ListarPaquetesEnviadosXCliente(int rut);

        List<Paquete> ListarPaquetesRecibidosXCliente(int rut);

        Local BuscarLocal(string nombre);
    }
}
