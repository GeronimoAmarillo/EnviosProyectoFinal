namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Casilla
    {
        public int Codigo { get; set; }

        public int Rack { get; set; }

        public  Rack Racks { get; set; }
        
        public  List<Palet> Palets { get; set; }
    }
}
