using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaCamioneta
    {
        bool AltaCamioneta(EntidadesCompartidasCore.Camioneta camioneta);

        List<EntidadesCompartidasCore.Camioneta> ListarCamionetas();

        bool BajaCamioneta(string matricula);

        bool ModificarCamioneta(EntidadesCompartidasCore.Camioneta camioneta);

        EntidadesCompartidasCore.Camioneta BuscarCamioneta(string matricula);

        bool ExisteCamioneta(string matricula);
    }
}
