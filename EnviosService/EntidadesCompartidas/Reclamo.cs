namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reclamo
    {
        public int Id { get; set; }
        
        public string Comentario { get; set; }
        
        public int Paquete { get; set; }

        public Paquetes Paquetes { get; set; }

        public Paquetes Paquetes1 { get; set; }
    }
}
