namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Multas
    {
        public int Id { get; set; }
        
        public string Vehiculo { get; set; }
        
        public decimal Suma { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public string Motivo { get; set; }

        public Vehiculos Vehiculos { get; set; }
    }
}
