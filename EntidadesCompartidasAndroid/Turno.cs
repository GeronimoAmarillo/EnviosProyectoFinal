namespace EntidadesCompartidasAndroid
{
    using System;
    using System.Collections.Generic;
    public partial class Turno
    {
        public string Codigo { get; set; }
        
        public string Dia { get; set; }

        public int Hora { get; set; }
        
        public List<Entrega> Entregas { get; set; }
    }
}
