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

        EntidadesCompartidasCore.Paquete BuscarPaqueteIndividual(int numReferencia, long cliente);

        List<EntidadesCompartidasCore.Paquete> ListarPaquetesEnviadosXCliente(long rut);


        bool RealizarReclamo(EntidadesCompartidasCore.Reclamo reclamo);

        List<EntidadesCompartidasCore.Paquete> ListarPaquetesRecibidosXCliente(long rut);

        List<EntidadesCompartidasCore.Reclamo> ListarReclamos();
    }
}
