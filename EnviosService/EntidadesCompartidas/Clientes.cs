namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Clientes
    {
        public long RUT { get; set; }

        public int IdUsuario { get; set; }
        
        public decimal Mensualidad { get; set; }
        
        public List<Calificaciones> Calificaciones { get; set; }
        
        public List<Paquetes> Paquetes { get; set; }

        public Usuarios Usuarios { get; set; }
        
        public List<Entregas> Entregas { get; set; }
        
        public List<Entregas> Entregas1 { get; set; }
        
        public List<Palets> Palets { get; set; }
        
        public List<Paquetes> Paquetes1 { get; set; }
    }
}
