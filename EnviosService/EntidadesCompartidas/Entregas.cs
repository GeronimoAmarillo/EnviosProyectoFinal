namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Entregas
    {
        public int Codigo { get; set; }
        
        public DateTime Fecha { get; set; }
        
        public string NombreReceptor { get; set; }

        public long ClienteReceptor { get; set; }

        public long ClienteEmisor { get; set; }

        public int LocalReceptor { get; set; }

        public int LocalEmisor { get; set; }
        
        public string Turno { get; set; }

        public Clientes Clientes { get; set; }

        public Clientes Clientes1 { get; set; }
        
        public List<Paquetes> Paquetes { get; set; }

        public Locales Locales { get; set; }

        public Locales Locales1 { get; set; }

        public Turnos Turnos { get; set; }
        
        public List<Paquetes> Paquetes1 { get; set; }
    }
}
