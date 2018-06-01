using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTCalificacion
    {
        public int Id { get; set; }
        public int Puntaje { get; set; }
        public string Comentario { get; set; }

        public DTCliente Cliente { get; set; }
    }
}
