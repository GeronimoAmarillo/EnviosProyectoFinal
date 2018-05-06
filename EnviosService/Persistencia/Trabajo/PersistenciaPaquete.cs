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
        public bool AltaPaquete(Paquetes paquete)
        {
            return true;
        }

        public Paquetes BuscarPaquete(int numReferencia)
        {
            return new Paquetes();
        }

        public List<Paquetes> ListarPaquetesEnviadosXCliente(int rut)
        {
            return new List<Paquetes>();
        }

        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }

        public List<Paquetes> ListarPaquetesRecibidosXCliente(int rut)
        {
            return new List<Paquetes>();
        }
    }
}
