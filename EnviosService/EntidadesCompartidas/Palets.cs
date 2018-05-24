namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Palets
    {
        public int Id { get; set; }
        
        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal Peso { get; set; }

        public int Casilla { get; set; }

        public long Cliente { get; set; }

        public Casillas Casillas { get; set; }

        public Clientes Clientes { get; set; }
    }
}
