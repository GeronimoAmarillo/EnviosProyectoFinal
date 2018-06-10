namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reclamo
    {
        public int Id { get; set; }
        
        public string Comentario { get; set; }
        
        public int Paquete { get; set; }

        public Paquete Paquetes { get; set; }

        public Paquete Paquetes1 { get; set; }
    }
}
