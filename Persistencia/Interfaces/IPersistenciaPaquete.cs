using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaPaquete
    {
        bool AltaPaquete(EntidadesCompartidas.Paquete paquete);

        EntidadesCompartidas.Paquete BuscarPaquete(int numReferencia);

        List<EntidadesCompartidas.Paquete> ListarPaquetesEnviadosXCliente(int rut);

        bool RealizarReclamo(string descripcion);

        List<EntidadesCompartidas.Paquete> ListarPaquetesRecibidosXCliente(int rut);
    }
}
