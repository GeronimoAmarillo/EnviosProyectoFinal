using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeApps.Models
{
    public class DTCasilla
    {

        public int Codigo { get; set; }

        public DTRack Rack { get; set; }
        public List<DTPalet> Palets { get; set; }
    }
}
