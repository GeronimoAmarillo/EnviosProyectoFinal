namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Empleado:Usuario
    {
        
        public decimal Sueldo { get; set; }
        
        public int Ci { get; set; }
        
        public  List<Adelanto> Adelantos { get; set; }

        public Cadete Cadetes { get; set; }
        
        public List<Administrador> Administradores { get; set; }

        public Usuario Usuarios { get; set; }
    }
}
