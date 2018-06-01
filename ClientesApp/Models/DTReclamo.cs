using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesApp.Models
{
    public class DTReclamo
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        public DTPaquete Paquete { get; set; }
    }
}
