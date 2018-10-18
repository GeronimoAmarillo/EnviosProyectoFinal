namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cliente:Usuario
    {
        [Required]
        public long RUT { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
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
