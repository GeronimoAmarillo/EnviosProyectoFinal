namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Local
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string Nombre { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Direccion { get; set; }
        public  List<Entrega> Entregas { get; set; }
        
        public  List<Entrega> Entregas1 { get; set; }
    }
}
