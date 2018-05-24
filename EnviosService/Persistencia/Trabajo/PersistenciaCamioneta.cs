using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    class PersistenciaCamioneta : IPersistenciaCamioneta
    {
        public bool AltaCamioneta(EntidadesCompartidas.Camionetas camioneta)
        {
            return true;
        }

        public List<EntidadesCompartidas.Camionetas> ListarCamionetas()
        {
            return new List<EntidadesCompartidas.Camionetas>();
        }

        public bool BajaCamioneta(string matricula)
        {
            return true;
        }

        public bool ModificarCamioneta(EntidadesCompartidas.Camionetas camioneta)
        {
            return true;
        }

        public EntidadesCompartidas.Camionetas BuscarCamioneta(string matricula)
        {
            return new EntidadesCompartidas.Camionetas();
        }

        public bool ExisteCamioneta(string matricula)
        {
            return true;
        }
    }
}
