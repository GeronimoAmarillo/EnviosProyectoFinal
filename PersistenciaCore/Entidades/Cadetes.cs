namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Cadetes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cadetes()
        {
            Vehiculos = new HashSet<Vehiculos>();
        }

        [Required]
        [StringLength(2)]
        public string TipoLibreta { get; set; }
       
        public long IdTelefono { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CiEmpleado { get; set; }

        [ForeignKey("Ci")]
        public virtual Empleados Empleados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
