namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Administradores
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CiEmpleado { get; set; }

        [Required]
        [Column(Order = 1)]
        [StringLength(1)]
        public string Tipo { get; set; }

        [ForeignKey("CiEmpleado")]
        public virtual Empleados Empleados { get; set; }
    }
}
