namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sector
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        [Range(1, Double.MaxValue)]
        public decimal Superficie { get; set; }
        [Required]
        [Range((-10), 50)]
        public int Temperatura { get; set; }
        [Required]
        public int Galpon { get; set; }

        public Galpon Galpones { get; set; }
        
        public  List<Rack> Racks { get; set; }
    }
}
