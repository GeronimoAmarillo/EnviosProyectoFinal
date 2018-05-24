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
        bool AltaPaquete(EntidadesCompartidas.Paquetes paquete);

        EntidadesCompartidas.Paquetes BuscarPaquete(int numReferencia);

        List<EntidadesCompartidas.Paquetes> ListarPaquetesEnviadosXCliente(int rut);

        bool RealizarReclamo(string descripcion);

        List<EntidadesCompartidas.Paquetes> ListarPaquetesRecibidosXCliente(int rut);
    }
}
