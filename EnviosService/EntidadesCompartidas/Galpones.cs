namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Galpones
    {
        public int Id { get; set; }

        public decimal Altura { get; set; }

        public decimal Superficie { get; set; }
        
        public  List<Sectores> Sectores { get; set; }
    }
}
