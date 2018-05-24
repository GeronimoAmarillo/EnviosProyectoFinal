namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Racks
    {
        public int Codigo { get; set; }

        public decimal Altura { get; set; }

        public decimal Superficie { get; set; }

        public int Sector { get; set; }
        
        public  List<Casillas> Casillas { get; set; }

        public  Sectores Sectores { get; set; }
    }
}
