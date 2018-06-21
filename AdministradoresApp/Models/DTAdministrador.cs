using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace AdministradoresApp.Models
{
    public class DTAdministrador: DTEmpleado
    {
        public string TipoAdministrador { get; set; }
    }
}
