namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Impuestos
    {
        public int Id { get; set; }
        
        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }
        
        public string Nombre { get; set; }
    }
}
