using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicaDeApps.Models
{
    public class DTCliente: DTUsuario
    {
        public long RUT { get; set; }
        public decimal Mensualidad { get; set; }
        
        public List<DTCalificacion> Calificaciones { get; set; }
        public List<DTEntrega> Entregas { get; set; }
    }
}
