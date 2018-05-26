using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaPaquete:IPersistenciaPaquete
    {
        public bool AltaPaquete(EntidadesCompartidas.Paquete paquete)
        {
            return true;
        }

        public EntidadesCompartidas.Paquete BuscarPaquete(int numReferencia)
        {
            return new EntidadesCompartidas.Paquete();
        }

        public List<EntidadesCompartidas.Paquete> ListarPaquetesEnviadosXCliente(int rut)
        {
            return new List<EntidadesCompartidas.Paquete>();
        }

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }

        public List<EntidadesCompartidas.Paquete> ListarPaquetesRecibidosXCliente(int rut)
        {
            return new List<EntidadesCompartidas.Paquete>();
        }
    }
}
