using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTTurno
    {
        public string Codigo { get; set; }
        public string Dia { get; set; }
        public int Hora { get; set; }
        
        public List<DTEntrega> Entregas { get; set; }
    }
}
