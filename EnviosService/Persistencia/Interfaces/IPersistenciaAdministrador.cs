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

        bool AltaAdministrador(Administradores administrador);

        bool ComprobarUser(string user);

        List<Administradores> ListarAdministradores();

        bool ModificarAdmin(Administradores admin);

        Administradores Login(string user, string contraseña);

        bool BajaAdministrador(int ci);

        Administradores BusxarAdministrador(int ci);
    }
}
