using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    class PersistenciaCamion:IPersistenciaCamion
    {
        public bool AltaCamion(EntidadesCompartidasCore.Camion camion)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Camion> ListarCamiones()
        {
            return new List<EntidadesCompartidasCore.Camion>();
        }

        public bool BajaCamion(string matricula)
        {
            return true;
        }

        public EntidadesCompartidasCore.Camion BuscarCamion(string matricula)
        {
            return new EntidadesCompartidasCore.Camion();
        }

        public bool ModificarCamion(EntidadesCompartidasCore.Camion camion)
        {
            return true;
        }

        public bool ExisteCamion(string matricula)
        {
            return true;
        }
    }
}
