using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeApps.Models
{
    public class DTAdministrador: DTEmpleado
    {
        public string TipoAdministrador { get; set; }
    }
}
