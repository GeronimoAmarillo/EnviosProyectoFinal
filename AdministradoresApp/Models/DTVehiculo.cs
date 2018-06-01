using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTVehiculo
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Capacidad { get; set; }
        public string Estado { get; set; }
        
        public List<DTMulta> Multas { get; set; }
        public List<DTReparacion> Reparaciones { get; set; }
    }
}
