using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaCamioneta : IPersistenciaCamioneta
    {
        public bool AltaCamioneta(EntidadesCompartidasCore.Camioneta camioneta)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Camioneta> ListarCamionetas()
        {
            return new List<EntidadesCompartidasCore.Camioneta>();
        }

        public bool BajaCamioneta(string matricula)
        {
            return true;
        }

        public bool ModificarCamioneta(EntidadesCompartidasCore.Camioneta camioneta)
        {
            return true;
        }

        public EntidadesCompartidasCore.Camioneta BuscarCamioneta(string matricula)
        {
            return new EntidadesCompartidasCore.Camioneta();
        }

        public bool ExisteCamioneta(string matricula)
        {
            return true;
        }
    }
}
