namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Ingreso
    {
        public int Id { get; set; }
        
        public string Descripcion { get; set; }
        
        public decimal Suma { get; set; }
    }
}
