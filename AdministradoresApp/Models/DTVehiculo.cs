using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTVehiculo
    {
        [Required]
        [StringLength(7)]
        public string Matricula { get; set; }
        [Required]
        [MinLength(2)]
        public string Marca { get; set; }
        [Required]
        [MinLength(1)]
        public string Modelo { get; set; }
        [Required]
        public decimal Capacidad { get; set; }
        [Required]
        [MinLength(2)]
        public string Estado { get; set; }
        public decimal Cilindrada { get; set; }
        public decimal Altura { get; set; }
        public int Puertas { get; set; }
        public string Cabina { get; set; }
        public string Tipo { get; set; }
        [Required]
        public int Cadete { get; set; }

        public List<DTMulta> Multas { get; set; }
        public List<DTReparacion> Reparaciones { get; set; }
    }
}
