using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
namespace Persistencia
{
    public interface IPersistenciaAuto
    {
        bool AltaAuto(EntidadesCompartidas.Automobil automobiles);

        List<EntidadesCompartidas.Automobil> ListarAutos();

        bool BajaAuto(string matricula);

        bool ModificarAuto(EntidadesCompartidas.Automobil auto);

        EntidadesCompartidas.Automobil BuscarAuto(string matricula);

        bool ExisteAuto(string matricula);
    }
}
