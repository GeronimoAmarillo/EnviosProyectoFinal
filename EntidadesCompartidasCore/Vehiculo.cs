namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Vehiculo
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

        public int Cadete { get; set; }

        public Automobil Automobiles { get; set; }

        public Cadete Cadetes { get; set; }

        public Camion Camiones { get; set; }

        public Camioneta Camionetas { get; set; }

        public Moto Motos { get; set; }
        
        public List<Multa> Multas { get; set; }
        
        public List<Reparacion> Reparaciones { get; set; }
    }
}
