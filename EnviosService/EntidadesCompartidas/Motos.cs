namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Motos
    {
        public decimal Cilindrada { get; set; }
        
        public string MatriculaMoto { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }
    }
}
