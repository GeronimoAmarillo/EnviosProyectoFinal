namespace EntidadesCompartidasAndroid
{
    using System;
    using System.Collections.Generic;

    public partial class Paquete
    {
        public int NumReferencia { get; set; }
        
        public DateTime FechaSalida { get; set; }
        
        public string Estado { get; set; }
        
        public string Ubicacion { get; set; }

        public int? Entrega { get; set; }

        public long? Cliente { get; set; }

        public  Cliente Clientes { get; set; }

        public  Cliente Clientes1 { get; set; }

        public  Entrega Entregas { get; set; }

        public  Entrega Entregas1 { get; set; }
        
        public  List<Reclamo> Reclamo { get; set; }
        
        public  List<Reclamo> Reclamo1 { get; set; }
    }
}
