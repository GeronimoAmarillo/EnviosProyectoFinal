namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Reparaciones
    {
        public int Id { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Taller { get; set; }
        
        public decimal Monto { get; set; }
        
        public string Vehiculo { get; set; }

        public Vehiculos Vehiculos { get; set; }
    }
}
