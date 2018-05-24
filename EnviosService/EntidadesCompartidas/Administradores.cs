namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Administradores
    {
        public int CiEmpleado { get; set; }
        
        public string Tipo { get; set; }

        public virtual Empleados Empleados { get; set; }
    }
}
