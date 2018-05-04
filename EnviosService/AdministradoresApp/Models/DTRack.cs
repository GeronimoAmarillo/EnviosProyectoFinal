using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTRack
    {

        public int Codigo { get; set; }
        public decimal Altura { get; set; }
        public decimal Superficie { get; set; }
        
        public List<DTCasilla> Casillas { get; set; }
        public DTSector Sector { get; set; }
    }
}
