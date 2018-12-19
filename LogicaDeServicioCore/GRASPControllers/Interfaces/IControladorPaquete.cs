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
        bool RealizarReclamo(EntidadesCompartidasCore.Reclamo reclamo);

        Paquete BuscarPaquete(int numReferencia);

        Paquete BuscarPaqueteIndividual(int numReferencia, long cliente);

        List<Local> ListarLocales();

        List<Paquete> ListarPaquetesEnviadosXCliente(long rut);

        List<Paquete> ListarPaquetesRecibidosXCliente(long rut);

        Local BuscarLocal(string nombre);

        List<EntidadesCompartidasCore.Reclamo> ListarReclamos();
    }
}
