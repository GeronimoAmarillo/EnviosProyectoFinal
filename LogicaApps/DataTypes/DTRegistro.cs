using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTRegistro
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal UtilidadBruta { get; set; }
        public decimal UtilidadOperacional { get; set; }
        public decimal UtilidadSinImpuestos { get; set; }
        public decimal UtilidadEjercicio { get; set; }

        public DTBalance Balance { get; set; }
    }
}
