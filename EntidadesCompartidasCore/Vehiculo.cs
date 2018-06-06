namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Vehiculo
    {
        public string Matricula { get; set; }
        
        public string Marca { get; set; }
        
        public string Modelo { get; set; }

        public decimal Capacidad { get; set; }
        
        public string Estado { get; set; }

        public int Cadete { get; set; }

        public Automobil Automobiles { get; set; }

        public Cadete Cadetes { get; set; }

        public Camion Camiones { get; set; }

        public Camioneta Camionetas { get; set; }

        public Moto Motos { get; set; }
        
        public List<Multa> Multas { get; set; }
        
        public List<Reparacion> Reparaciones { get; set; }
    }
}
