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
        bool AltaCamion(Camiones camion);

        List<Camiones> ListarCamiones();

        bool BajaCamion(string matricula);

        Camiones BuscarCamion(string matricula);

        bool ModificarCamion(Camiones camion);

        bool ExisteCamion(string matricula);
    }
}
