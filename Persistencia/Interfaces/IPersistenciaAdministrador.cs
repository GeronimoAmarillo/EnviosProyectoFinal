using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaAdministrador
    {
        bool ExisteAdmin(int ci);

        bool AltaAdministrador(EntidadesCompartidas.Administrador administrador);

        bool ComprobarUser(string user);

        List<EntidadesCompartidas.Administrador> ListarAdministradores();

        bool ModificarAdmin(EntidadesCompartidas.Administrador admin);

        EntidadesCompartidas.Administrador Login(string user, string contraseña);

        bool BajaAdministrador(int ci);

        EntidadesCompartidas.Administrador BusxarAdministrador(int ci);
    }
}
