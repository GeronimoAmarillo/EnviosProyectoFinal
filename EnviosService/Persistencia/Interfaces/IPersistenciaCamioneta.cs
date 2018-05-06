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
        bool AltaCamioneta(Camionetas camioneta);

        List<Camionetas> ListarCamionetas();

        bool BajaCamioneta(string matricula);

        bool ModificarCamioneta(Camionetas camioneta);

        Camionetas BuscarCamioneta(string matricula);

        bool ExisteCamioneta(string matricula);
    }
}
