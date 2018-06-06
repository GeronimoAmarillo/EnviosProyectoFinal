namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Camiones
    {
        public decimal Altura { get; set; }

        [Key]
        [StringLength(10)]
        public string MatriculaCamion { get; set; }
        [ForeignKey("Matricula")]
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
