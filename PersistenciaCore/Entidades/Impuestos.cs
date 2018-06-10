namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Impuestos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }
        [Required]
        public decimal Porcentaje { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
