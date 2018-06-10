namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Galpones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Galpones()
        {
            Sectores = new HashSet<Sectores>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Altura { get; set; }
        [Required]
        public decimal Superficie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sectores> Sectores { get; set; }
    }
}
