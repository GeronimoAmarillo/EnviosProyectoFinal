namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Empleado:Usuario
    {
        [Required]
        public decimal Sueldo { get; set; }

        public int IdUsuario { get; set; }
        [Required]
        public int Ci { get; set; }
        
        public  List<Adelanto> Adelantos { get; set; }

        public Cadete Cadetes { get; set; }
        
        public List<Administrador> Administradores { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
