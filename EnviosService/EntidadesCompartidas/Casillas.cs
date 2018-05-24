namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Casillas
    {
        public int Codigo { get; set; }

        public int Rack { get; set; }

        public  Racks Racks { get; set; }
        
        public  List<Palets> Palets { get; set; }
    }
}
