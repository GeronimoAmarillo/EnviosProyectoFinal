namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Camionetas
    {
        [Required]
        [StringLength(25)]
        public string Cabina { get; set; }

        [Key]
        [StringLength(10)]
        public string MatriculaCamioneta { get; set; }
        [ForeignKey("Matricula")]
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
