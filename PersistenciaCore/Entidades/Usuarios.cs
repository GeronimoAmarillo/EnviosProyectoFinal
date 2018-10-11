namespace PersistenciaCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            Clientes = new HashSet<Clientes>();
            Empleados = new HashSet<Empleados>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(25)]
        public string Contraseña { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string Direccion { get; set; }


        [StringLength(5)]
        public string CodigoRecuperacionContraseña { get; set; }

        [StringLength(5)]
        public string CodigoModificarEmail { get; set; }

        [Required]
        [StringLength(25)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
