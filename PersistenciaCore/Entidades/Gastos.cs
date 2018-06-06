namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Gastos
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal Suma { get; set; }
    }
}
