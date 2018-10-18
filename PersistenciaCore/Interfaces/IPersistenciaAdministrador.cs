using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace PersistenciaCore
{
    public interface IPersistenciaAdministrador
    {
        bool ExisteAdmin(int ci);
        
        bool VerificarCodigoContraseña(string email, string codigo);

        bool VerificarCodigoEmail(string email, string codigo);

        bool AltaAdministrador(Administrador administrador);

        bool ComprobarUser(string user);

        List<Administrador> ListarAdministradores();

        bool ModificarAdmin(Administrador admin);

        Administrador Login(string user, string contraseña);

        bool BajaAdministrador(int ci);

        Administrador BuscarAdministrador(int ci);
        
        bool SetearCodigoRecuperacionContraseña(Administrador admin);

        bool SetearCodigoModificarEmail(Administrador admin);

        bool ModificarContrasenia(Administrador unAdmin);
    }
}
