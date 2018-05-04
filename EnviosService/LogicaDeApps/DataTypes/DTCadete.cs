using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeApps.Models
{
    public class DTCadete: DTEmpleado
    {
        public string TipoLibreta { get; set; }
        public long IdTelefono { get; set; }
    }
}
