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

        bool AltaAdministrador(EntidadesCompartidas.Administradores administrador);

        bool ComprobarUser(string user);

        List<EntidadesCompartidas.Administradores> ListarAdministradores();

        bool ModificarAdmin(EntidadesCompartidas.Administradores admin);

        EntidadesCompartidas.Administradores Login(string user, string contraseña);

        bool BajaAdministrador(int ci);

        EntidadesCompartidas.Administradores BusxarAdministrador(int ci);
    }
}
