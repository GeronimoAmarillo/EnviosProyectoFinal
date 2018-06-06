namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Usuario
    {

        public int Id { get; set; }
        
        public string NombreUsuario { get; set; }
        
        public string Contraseña { get; set; }
        
        public string Nombre { get; set; }
        
        public string Direccion { get; set; }
        
        public string Telefono { get; set; }
        
        public string Email { get; set; }
        
        public List<Cliente> Clientes { get; set; }
        
        public List<Empleado> Empleados { get; set; }
    }
}
