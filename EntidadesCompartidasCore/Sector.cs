namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Sector
    {
        public int Codigo { get; set; }

        public decimal Superficie { get; set; }

        public int Temperatura { get; set; }

        public int Galpon { get; set; }

        public Galpon Galpones { get; set; }
        
        public  List<Rack> Racks { get; set; }
    }
}
