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
        bool AltaAuto(Automobiles automobiles);

        List<Automobiles> ListarAutos();

        bool BajaAuto(string matricula);

        bool ModificarAuto(Automobiles auto);

        Automobiles BuscarAuto(string matricula);

        bool ExisteAuto(string matricula);
    }
}
