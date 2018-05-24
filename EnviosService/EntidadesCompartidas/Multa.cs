namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Multa
    {
        public int Id { get; set; }
        
        public string Vehiculo { get; set; }
        
        public decimal Suma { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public string Motivo { get; set; }

        public Vehiculo Vehiculos { get; set; }
    }
}
