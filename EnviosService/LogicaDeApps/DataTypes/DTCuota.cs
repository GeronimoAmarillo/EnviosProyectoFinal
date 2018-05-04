using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeApps.Models
{
    public class DTCuota
    {
        public DateTime Vencimiento { get; set; }
        public decimal Suma { get; set; }
        public bool Pagada { get; set; }

        public DTAdelanto adelanto { get; set; }
    }
}
