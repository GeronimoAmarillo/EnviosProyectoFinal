using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaPaquete:IPersistenciaPaquete
    {
        public bool AltaPaquete(EntidadesCompartidasCore.Paquete paquete)
        {
            return true;
        }

        public EntidadesCompartidasCore.Paquete BuscarPaquete(int numReferencia)
        {
            return new EntidadesCompartidasCore.Paquete();
        }

        public List<EntidadesCompartidasCore.Paquete> ListarPaquetesEnviadosXCliente(int rut)
        {
            return new List<EntidadesCompartidasCore.Paquete>();
        }

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Paquete> ListarPaquetesRecibidosXCliente(int rut)
        {
            return new List<EntidadesCompartidasCore.Paquete>();
        }
    }
}
