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
        bool AltaCamion(EntidadesCompartidas.Camion camion);

        List<EntidadesCompartidas.Camion> ListarCamiones();

        bool BajaCamion(string matricula);

        EntidadesCompartidas.Camion BuscarCamion(string matricula);

        bool ModificarCamion(EntidadesCompartidas.Camion camion);

        bool ExisteCamion(string matricula);
    }
}
