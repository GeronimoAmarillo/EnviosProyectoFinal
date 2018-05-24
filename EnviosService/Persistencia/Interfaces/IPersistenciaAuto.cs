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
        bool AltaAuto(EntidadesCompartidas.Automobiles automobiles);

        List<EntidadesCompartidas.Automobiles> ListarAutos();

        bool BajaAuto(string matricula);

        bool ModificarAuto(EntidadesCompartidas.Automobiles auto);

        EntidadesCompartidas.Automobiles BuscarAuto(string matricula);

        bool ExisteAuto(string matricula);
    }
}
