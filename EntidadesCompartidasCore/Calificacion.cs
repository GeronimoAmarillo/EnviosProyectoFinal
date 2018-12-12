namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Calificacion
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(1,5, ErrorMessage = "debe ingresar un valor del 1 al 5")]
        public int Puntaje { get; set; }
        [Required]
        public long RutCliente { get; set; }
        [Required]
        [MinLength(5, ErrorMessage ="El comentario debe poseer mas de 5 caracteres")]
        public string Comentario { get; set; }

        public Cliente Clientes { get; set; }
    }
}
