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

        EntidadesCompartidasCore.Paquete BuscarPaqueteIndividual(int numReferencia, int cliente);

        List<EntidadesCompartidasCore.Paquete> ListarPaquetesEnviadosXCliente(int rut);


        bool RealizarReclamo(EntidadesCompartidasCore.Reclamo reclamo);

        List<EntidadesCompartidasCore.Paquete> ListarPaquetesRecibidosXCliente(int rut);
    }
}
