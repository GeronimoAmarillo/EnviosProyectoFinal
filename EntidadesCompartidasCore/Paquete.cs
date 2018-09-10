namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Paquete
    {
        [Required]
        public int NumReferencia { get; set; }
        [Required]
        public DateTime FechaSalida { get; set; }
        [Required]
        [MinLength(2)]
        public string Estado { get; set; }
        [Required]
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
