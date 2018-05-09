using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorEntrega:IControladorEntrega
    {
        
        public List<Entregas> ListarEntregas()
        {
            return new List<Entregas>();
        }


        public bool Entregar(List<Entregas> entregasSeleccionadas)
        {
            return true;
        }

        public List<Clientes> ListarClientes()
        {
            return new List<Clientes>();
        }

        public List<Cadetes> ListarCadetesDisponibles()
        {
            return new List<Cadetes>();
        }
        
        public List<Turnos> ListarTurnos()
        {
            return new List<Turnos>();
        }

        public List<Locales> ListarLocales()
        {
            return new List<Locales>();
        }

        public bool AltaEntrega(Entregas pEntrega)
        {
            return true;
        }
    }
}
