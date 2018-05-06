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
        bool AltaMoto(Motos moto);

        bool ExisteMoto(string matricula);

        Motos BuscarMoto(string matricula);

        List<Motos> ListarMotos();

        bool BajaMoto(string matricula);

        bool ModificarMoto(Motos moto);
    }
}
