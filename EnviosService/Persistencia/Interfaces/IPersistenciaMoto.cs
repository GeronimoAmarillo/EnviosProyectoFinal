using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
namespace Persistencia
{
    public interface IPersistenciaMoto
    {
        bool AltaMoto(EntidadesCompartidas.Moto moto);

        bool ExisteMoto(string matricula);

        EntidadesCompartidas.Moto BuscarMoto(string matricula);

        List<EntidadesCompartidas.Moto> ListarMotos();

        bool BajaMoto(string matricula);

        bool ModificarMoto(EntidadesCompartidas.Moto moto);
    }
}
