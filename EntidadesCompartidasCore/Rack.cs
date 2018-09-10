namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Rack
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        [Range(1, Double.MaxValue)]
        public decimal Altura { get; set; }
        [Required]
        [Range(1, Double.MaxValue)]
        public decimal Superficie { get; set; }
        [Required]
        public int Sector { get; set; }
        
        public  List<Casilla> Casillas { get; set; }

        public  Sector Sectores { get; set; }
    }
}
