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
        public decimal Cilindrada { get; set; }
        public decimal Altura { get; set; }
        public int Puertas { get; set; }
        public string Cabina { get; set; }
        public string Tipo { get; set; }
        public int Cadete { get; set; }

        public List<DTMulta> Multas { get; set; }
        public List<DTReparacion> Reparaciones { get; set; }
    }
}
