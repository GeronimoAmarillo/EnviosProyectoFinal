using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeApps.Models
{
    public class DTSector
    {

        public int Codigo { get; set; }
        public decimal Superficie { get; set; }
        public int Temperatura { get; set; }
        
        public List<DTRack> Racks { get; set; }
    }
}
