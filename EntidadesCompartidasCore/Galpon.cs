namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Galpon
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Altura { get; set; }
        [Required]
        [Range(50, double.MaxValue)]
        public decimal Superficie { get; set; }
        
        public  List<Sector> Sectores { get; set; }
    }
}
