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
        bool AltaCadete(EntidadesCompartidas.Cadete cadete);

        bool ExisteCadete(int ci);

        List<EntidadesCompartidas.Cadete> ListarCadetes();

        EntidadesCompartidas.Cadete Login(string user, string contraseña);

        bool ModificarCadete(EntidadesCompartidas.Cadete cadete);

        List<EntidadesCompartidas.Cadete> ListarCadetesDisponibles();

        bool BajaCadete(int ci);

        bool ComprobarUser(string user);

        EntidadesCompartidas.Cadete BuscarCadete(int ci);
    }
}
