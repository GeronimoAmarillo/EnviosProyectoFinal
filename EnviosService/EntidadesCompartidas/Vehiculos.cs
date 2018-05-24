namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Vehiculos
    {
        public string Matricula { get; set; }
        
        public string Marca { get; set; }
        
        public string Modelo { get; set; }

        public decimal Capacidad { get; set; }
        
        public string Estado { get; set; }

        public int Cadete { get; set; }

        public Automobiles Automobiles { get; set; }

        public Cadetes Cadetes { get; set; }

        public Camiones Camiones { get; set; }

        public Camionetas Camionetas { get; set; }

        public Motos Motos { get; set; }
        
        public List<Multas> Multas { get; set; }
        
        public List<Reparaciones> Reparaciones { get; set; }
    }
}
