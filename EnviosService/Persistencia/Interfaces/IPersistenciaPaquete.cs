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
        bool AltaPaquete(Paquetes paquete);

        Paquetes BuscarPaquete(int numReferencia);

        List<Paquetes> ListarPaquetesEnviadosXCliente(int rut);

        bool RealizarReclamo(string descripcion);

        List<Paquetes> ListarPaquetesRecibidosXCliente(int rut);
    }
}
