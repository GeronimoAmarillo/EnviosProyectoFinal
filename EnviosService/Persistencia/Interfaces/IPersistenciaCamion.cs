using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCamion
    {
        bool AltaCamion(EntidadesCompartidas.Camiones camion);

        List<EntidadesCompartidas.Camiones> ListarCamiones();

        bool BajaCamion(string matricula);

        EntidadesCompartidas.Camiones BuscarCamion(string matricula);

        bool ModificarCamion(EntidadesCompartidas.Camiones camion);

        bool ExisteCamion(string matricula);
    }
}
