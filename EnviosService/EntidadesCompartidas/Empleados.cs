namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Empleados
    {
        
        public decimal Sueldo { get; set; }

        public int IdUsuario { get; set; }
        
        public int Ci { get; set; }
        
        public  List<Adelantos> Adelantos { get; set; }

        public Cadetes Cadetes { get; set; }
        
        public List<Administradores> Administradores { get; set; }

        public Usuarios Usuarios { get; set; }
    }
}
