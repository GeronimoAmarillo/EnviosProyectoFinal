using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeApps.Models
{
    public class DTPaquete
    {
        public int NumReferencia { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Estado { get; set; }
        public string Ubicacion { get; set; }

        public DTCliente Cliente { get; set; }
        public DTEntrega Entrega { get; set; }

        public List<DTReclamo> Reclamos { get; set; }
    }
}
