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
        public bool AltaCamioneta(EntidadesCompartidas.Camioneta camioneta)
        {
            return true;
        }

        public List<EntidadesCompartidas.Camioneta> ListarCamionetas()
        {
            return new List<EntidadesCompartidas.Camioneta>();
        }

        public bool BajaCamioneta(string matricula)
        {
            return true;
        }

        public bool ModificarCamioneta(EntidadesCompartidas.Camioneta camioneta)
        {
            return true;
        }

        public EntidadesCompartidas.Camioneta BuscarCamioneta(string matricula)
        {
            return new EntidadesCompartidas.Camioneta();
        }

        public bool ExisteCamioneta(string matricula)
        {
            return true;
        }
    }
}
