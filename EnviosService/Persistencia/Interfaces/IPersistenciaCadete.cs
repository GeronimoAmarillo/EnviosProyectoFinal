using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
namespace Persistencia
{
    public interface IPersistenciaCadete
    {
        bool AltaCadete(EntidadesCompartidas.Cadetes cadete);

        bool ExisteCadete(int ci);

        List<EntidadesCompartidas.Cadetes> ListarCadetes();

        EntidadesCompartidas.Cadetes Login(string user, string contraseña);

        bool ModificarCadete(EntidadesCompartidas.Cadetes cadete);

        List<EntidadesCompartidas.Cadetes> ListarCadetesDisponibles();

        bool BajaCadete(int ci);

        bool ComprobarUser(string user);

        EntidadesCompartidas.Cadetes BuscarCadete(int ci);
    }
}
