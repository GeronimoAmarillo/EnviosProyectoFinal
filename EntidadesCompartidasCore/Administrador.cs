namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public class Administrador:Empleado
    {
        
        public string Tipo { get; set; }

        public Empleado Empleados { get; set; }
    }
}
