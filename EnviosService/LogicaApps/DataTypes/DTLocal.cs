using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministradoresApp.Models
{
    public class DTLocal
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public List<DTEntrega> EntregasEnviadas { get; set; }
        public List<DTEntrega> EntregasRecibidas { get; set; }
    }
}
