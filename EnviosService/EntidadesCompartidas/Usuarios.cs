namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Usuarios
    {

        public int Id { get; set; }
        
        public string NombreUsuario { get; set; }
        
        public string Contraseña { get; set; }
        
        public string Nombre { get; set; }
        
        public string Direccion { get; set; }
        
        public string Telefono { get; set; }
        
        public string Email { get; set; }
        
        public List<Clientes> Clientes { get; set; }
        
        public List<Empleados> Empleados { get; set; }
    }
}
