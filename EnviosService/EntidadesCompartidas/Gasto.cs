namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Gasto
    {
        public int Id { get; set; }
        
        public string Descripcion { get; set; }
        
        public decimal Suma { get; set; }
    }
}
