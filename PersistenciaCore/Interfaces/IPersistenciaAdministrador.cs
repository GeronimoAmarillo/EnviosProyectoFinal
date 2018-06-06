﻿using System;
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

        bool AltaAdministrador(Administrador administrador);

        bool ComprobarUser(string user);

        List<Administrador> ListarAdministradores();

        bool ModificarAdmin(Administrador admin);

        Administrador Login(string user, string contraseña);

        bool BajaAdministrador(int ci);

        Administrador BusxarAdministrador(int ci);
    }
}
