namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Sectores
    {
        public int Codigo { get; set; }

        public decimal Superficie { get; set; }

        public int Temperatura { get; set; }

        public int Galpon { get; set; }

        public Galpones Galpones { get; set; }
        
        public  List<Racks> Racks { get; set; }
    }
}
