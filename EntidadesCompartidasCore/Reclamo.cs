namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Reclamo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(20)]
        public string Comentario { get; set; }
        [Required]
        public int Paquete { get; set; }

        public Paquete Paquetes { get; set; }

        public Paquete Paquetes1 { get; set; }
    }
}
