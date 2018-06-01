namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Palet
    {
        public int Id { get; set; }
        
        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal Peso { get; set; }

        public int Casilla { get; set; }

        public long Cliente { get; set; }

        public Casilla Casillas { get; set; }

        public Cliente Clientes { get; set; }
    }
}
