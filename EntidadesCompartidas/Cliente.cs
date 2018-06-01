namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Cliente:Usuario
    {
        public long RUT { get; set; }

        public int IdUsuario { get; set; }
        
        public decimal Mensualidad { get; set; }
        
        public List<Calificacion> Calificaciones { get; set; }
        
        public List<Paquete> Paquetes { get; set; }

        public Usuario Usuarios { get; set; }
        
        public List<Entrega> Entregas { get; set; }
        
        public List<Entrega> Entregas1 { get; set; }
        
        public List<Palet> Palets { get; set; }
        
        public List<Paquete> Paquetes1 { get; set; }
    }
}
