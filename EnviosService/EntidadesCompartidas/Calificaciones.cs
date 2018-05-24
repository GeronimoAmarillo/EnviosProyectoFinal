namespace EntidadesCompartidas
{
    using System;
    using System.Collections.Generic;

    public partial class Calificaciones
    {
        public int Id { get; set; }

        public int Puntaje { get; set; }
        
        public long RutCliente { get; set; }
        
        public string Comentario { get; set; }

        public Clientes Clientes { get; set; }
    }
}
