﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTUsuario
    {

        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public decimal Sueldo { get; set; }
        public int Ci { get; set; }
        public string TipoAdministrador { get; set; }
        public string TipoLibreta { get; set; }
        public long IdTelefono { get; set; }

    }
}
