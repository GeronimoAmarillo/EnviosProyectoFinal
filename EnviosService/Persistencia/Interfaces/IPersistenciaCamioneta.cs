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
        bool AltaCamioneta(EntidadesCompartidas.Camionetas camioneta);

        List<EntidadesCompartidas.Camionetas> ListarCamionetas();

        bool BajaCamioneta(string matricula);

        bool ModificarCamioneta(EntidadesCompartidas.Camionetas camioneta);

        EntidadesCompartidas.Camionetas BuscarCamioneta(string matricula);

        bool ExisteCamioneta(string matricula);
    }
}
