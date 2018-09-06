namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Reparaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(25)]
        public string Taller { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Monto { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Vehiculo { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }
    }
}
