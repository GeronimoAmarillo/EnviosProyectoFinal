namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Balances
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Balances()
        {
            Registros = new HashSet<Registros>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Mes { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        public bool Abierto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registros> Registros { get; set; }
    }
}
