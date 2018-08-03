namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            Adelantos = new HashSet<Adelantos>();
        }

        [Column(TypeName = "money")]
        public decimal Sueldo { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ci { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adelantos> Adelantos { get; set; }

        public virtual Cadetes Cadetes { get; set; }
        
        public virtual  Administradores Administradores { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuarios Usuarios { get; set; }
    }
}
