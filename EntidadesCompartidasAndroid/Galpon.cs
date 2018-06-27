namespace EntidadesCompartidasAndroid
{
    using System;
    using System.Collections.Generic;

    public partial class Galpon
    {
        public int Id { get; set; }

        public decimal Altura { get; set; }

        public decimal Superficie { get; set; }
        
        public  List<Sector> Sectores { get; set; }
    }
}
