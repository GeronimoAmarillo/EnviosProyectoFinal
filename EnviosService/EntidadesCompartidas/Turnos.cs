namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;
    public partial class Turnos
    {
        public string Codigo { get; set; }
        
        public string Dia { get; set; }

        public int Hora { get; set; }
        
        public List<Entregas> Entregas { get; set; }
    }
}
