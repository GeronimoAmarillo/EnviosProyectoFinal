using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
namespace PersistenciaCore
{
    public interface IPersistenciaCadete
    {
        bool AltaCadete(EntidadesCompartidasCore.Cadete cadete);

        bool VerificarCodigoContraseña(string email, string codigo);

        bool VerificarCodigoEmail(string email, string codigo);

        bool ExisteCadete(int ci);

        List<EntidadesCompartidasCore.Cadete> ListarCadetes();

        EntidadesCompartidasCore.Cadete Login(string user, string contraseña);

        bool ModificarCadete(EntidadesCompartidasCore.Cadete cadete);

        List<EntidadesCompartidasCore.Cadete> ListarCadetesDisponibles();

        bool BajaCadete(int ci);

        bool ComprobarUser(string user);

        bool SetearCodigoRecuperacionContraseña(Cadete cadete);

        bool SetearCodigoModificarEmail(Cadete cadete);

        EntidadesCompartidasCore.Cadete BuscarCadete(int ci);
    }
}
