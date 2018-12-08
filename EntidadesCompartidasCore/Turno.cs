namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Turno
    {
        [Required]
        [StringLength(7)]
        public string Codigo { get; set; }
        [Required]
        [MinLength(5), MaxLength(9)]
        public string Dia { get; set; }
        [Required]
        [Range(0, 2400)]
        public int Hora { get; set; }
        
        public bool Eliminado { get; set; }

        public List<Entrega> Entregas { get; set; }
    }
}
