using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaCamion
    {
        bool AltaCamion(EntidadesCompartidasCore.Camion camion);

        List<EntidadesCompartidasCore.Camion> ListarCamiones();

        bool BajaCamion(string matricula);

        EntidadesCompartidasCore.Camion BuscarCamion(string matricula);

        bool ModificarCamion(EntidadesCompartidasCore.Camion camion);

        bool ExisteCamion(string matricula);
    }
}
