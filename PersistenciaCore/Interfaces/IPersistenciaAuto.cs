using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
namespace PersistenciaCore
{
    public interface IPersistenciaAuto
    {
        bool AltaAuto(EntidadesCompartidasCore.Automobil automobiles);

        List<EntidadesCompartidasCore.Automobil> ListarAutos();

        bool BajaAuto(string matricula);

        bool ModificarAuto(EntidadesCompartidasCore.Automobil auto);

        EntidadesCompartidasCore.Automobil BuscarAuto(string matricula);

        bool ExisteAuto(string matricula);
    }
}
