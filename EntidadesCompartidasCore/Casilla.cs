namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Casilla
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public int Rack { get; set; }

        public  Rack Racks { get; set; }
        
        public  List<Palet> Palets { get; set; }
    }
}
