namespace EntidadesCompartidasCore
{
    using System;
    using System.Collections.Generic;

    public partial class Calificacion
    {
        public int Id { get; set; }

        public int Puntaje { get; set; }
        
        public long RutCliente { get; set; }
        
        public string Comentario { get; set; }

        public Cliente Clientes { get; set; }
    }
}
