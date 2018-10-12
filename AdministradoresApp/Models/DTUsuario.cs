using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.

namespace AdministradoresApp.Models
{
    public class DTUsuario
    {

        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        public string NuevoNombreUsuario { get; set; }

        [Required]
        public string Contraseña { get; set; }

        public string NuevaContrasenia { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }
        
    }
}
