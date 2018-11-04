namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Entrega
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [MinLength(2)]
        public string NombreReceptor { get; set; }
        public long? ClienteReceptor { get; set; }
        public long? ClienteEmisor { get; set; }
        public int? LocalReceptor { get; set; }
        public int? LocalEmisor { get; set; }
        [Required]
        public string Turno { get; set; }

        public Cliente Clientes { get; set; }

        public Cliente Clientes1 { get; set; }
        
        public List<Paquete> Paquetes { get; set; }

        public Local Locales { get; set; }

        public Local Locales1 { get; set; }

        public Turno Turnos { get; set; }
        
        public List<Paquete> Paquetes1 { get; set; }

        public long? Cadete { get; set; }

        public virtual Cadete Cadetes { get; set; }
    }
}
