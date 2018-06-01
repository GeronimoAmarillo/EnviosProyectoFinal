using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTEmpleado: DTUsuario
    {

        public decimal Sueldo { get; set; }
        public int Ci { get; set; }
        
        public List<DTAdelanto> Adelantos { get; set; }
    }
}
