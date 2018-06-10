using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
namespace PersistenciaCore
{
    public interface IPersistenciaMoto
    {
        bool AltaMoto(EntidadesCompartidasCore.Moto moto);

        bool ExisteMoto(string matricula);

        EntidadesCompartidasCore.Moto BuscarMoto(string matricula);

        List<EntidadesCompartidasCore.Moto> ListarMotos();

        bool BajaMoto(string matricula);

        bool ModificarMoto(EntidadesCompartidasCore.Moto moto);
    }
}
