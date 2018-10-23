namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Administrador : Empleado
    {
        [Required]
        [Range(1000000, 99999999)]
        public int CiEmpleado { get; set; }
       
        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }
        
        public Empleado Empleados { get; set; }
    }
}

