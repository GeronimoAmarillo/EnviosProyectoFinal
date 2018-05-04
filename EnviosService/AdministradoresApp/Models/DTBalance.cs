using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTBalance
    {
        public int Id { get; set; }
        public string Mes { get; set; }
        public int Año { get; set; }
        public bool Abierto { get; set; }
        
        public  List<DTRegistro> Registros { get; set; }
    }
}
