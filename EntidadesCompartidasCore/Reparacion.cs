namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Reparacion
    {
        public int Id { get; set; }
        
        public string Descripcion { get; set; }
        
        public string Taller { get; set; }
        
        public decimal Monto { get; set; }
        
        public string Vehiculo { get; set; }

        public Vehiculo Vehiculos { get; set; }
    }
}
