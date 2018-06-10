namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Rack
    {
        public int Codigo { get; set; }

        public decimal Altura { get; set; }

        public decimal Superficie { get; set; }

        public int Sector { get; set; }
        
        public  List<Casilla> Casillas { get; set; }

        public  Sector Sectores { get; set; }
    }
}
