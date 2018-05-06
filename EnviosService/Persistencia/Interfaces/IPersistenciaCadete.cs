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
        bool AltaCadete(Cadetes cadete);

        bool ExisteCadete(int ci);

        List<Cadetes> ListarCadetes();

        Cadetes Login(string user, string contraseña);

        bool ModificarCadete(Cadetes cadete);

        List<Cadetes> ListarCadetesDisponibles();

        bool BajaCadete(int ci);

        bool ComprobarUser(string user);

        Cadetes BuscarCadete(int ci);
    }
}
