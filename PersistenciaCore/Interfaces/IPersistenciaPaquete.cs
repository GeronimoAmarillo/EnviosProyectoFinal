using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaPaquete
    {
        bool AltaPaquete(EntidadesCompartidasCore.Paquete paquete);

        EntidadesCompartidasCore.Paquete BuscarPaquete(int numReferencia);

        List<EntidadesCompartidasCore.Paquete> ListarPaquetesEnviadosXCliente(int rut);

        bool RealizarReclamo(string descripcion);

        List<EntidadesCompartidasCore.Paquete> ListarPaquetesRecibidosXCliente(int rut);
    }
}
