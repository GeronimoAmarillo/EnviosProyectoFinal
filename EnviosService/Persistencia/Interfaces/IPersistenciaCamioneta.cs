using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCamioneta
    {
        bool AltaCamioneta(EntidadesCompartidas.Camioneta camioneta);

        List<EntidadesCompartidas.Camioneta> ListarCamionetas();

        bool BajaCamioneta(string matricula);

        bool ModificarCamioneta(EntidadesCompartidas.Camioneta camioneta);

        EntidadesCompartidas.Camioneta BuscarCamioneta(string matricula);

        bool ExisteCamioneta(string matricula);
    }
}
