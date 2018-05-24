namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Paquetes
    {
        public int NumReferencia { get; set; }
        
        public DateTime FechaSalida { get; set; }
        
        public string Estado { get; set; }
        
        public string Ubicacion { get; set; }

        public int? Entrega { get; set; }

        public long? Cliente { get; set; }

        public  Clientes Clientes { get; set; }

        public  Clientes Clientes1 { get; set; }

        public  Entregas Entregas { get; set; }

        public  Entregas Entregas1 { get; set; }
        
        public  List<Reclamo> Reclamo { get; set; }
        
        public  List<Reclamo> Reclamo1 { get; set; }
    }
}
