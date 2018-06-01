using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeApps.Models
{
    public class DTImpuesto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
        public string Nombre { get; set; }
    }
}
