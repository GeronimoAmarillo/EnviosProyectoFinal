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
        public bool AltaPaquete(EntidadesCompartidas.Paquetes paquete)
        {
            return true;
        }

        public EntidadesCompartidas.Paquetes BuscarPaquete(int numReferencia)
        {
            return new EntidadesCompartidas.Paquetes();
        }

        public List<EntidadesCompartidas.Paquetes> ListarPaquetesEnviadosXCliente(int rut)
        {
            return new List<EntidadesCompartidas.Paquetes>();
        }

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }

        public List<EntidadesCompartidas.Paquetes> ListarPaquetesRecibidosXCliente(int rut)
        {
            return new List<EntidadesCompartidas.Paquetes>();
        }
    }
}
