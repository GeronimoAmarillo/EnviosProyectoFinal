namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Cuotas
    {
        public DateTime Vencimiento { get; set; }
        
        public int IdAdelanto { get; set; }
        
        public decimal Suma { get; set; }

        public bool Pagada { get; set; }
    }
}
