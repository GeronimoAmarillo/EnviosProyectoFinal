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
        public bool AltaCamioneta(Camionetas camioneta)
        {
            return true;
        }

        public List<Camionetas> ListarCamionetas()
        {
            return new List<Camionetas>();
        }

        public bool BajaCamioneta(string matricula)
        {
            return true;
        }

        public bool ModificarCamioneta(Camionetas camioneta)
        {
            return true;
        }

        public Camionetas BuscarCamioneta(string matricula)
        {
            return new Camionetas();
        }

        public bool ExisteCamioneta(string matricula)
        {
            return true;
        }
    }
}
