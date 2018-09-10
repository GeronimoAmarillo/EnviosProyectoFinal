namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Turno
    {
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Dia { get; set; }
        [Required]
        public int Hora { get; set; }
        
        public List<Entrega> Entregas { get; set; }
    }
}
