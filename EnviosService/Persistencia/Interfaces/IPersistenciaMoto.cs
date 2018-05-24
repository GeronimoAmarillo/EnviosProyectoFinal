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
        bool AltaMoto(EntidadesCompartidas.Motos moto);

        bool ExisteMoto(string matricula);

        EntidadesCompartidas.Motos BuscarMoto(string matricula);

        List<EntidadesCompartidas.Motos> ListarMotos();

        bool BajaMoto(string matricula);

        bool ModificarMoto(EntidadesCompartidas.Motos moto);
    }
}
