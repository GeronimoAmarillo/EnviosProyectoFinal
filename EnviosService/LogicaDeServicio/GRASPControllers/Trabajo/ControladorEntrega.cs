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
        
        public List<EntidadesCompartidas.Entregas> ListarEntregas()
        {
            return new List<EntidadesCompartidas.Entregas>();
        }


        public bool Entregar(List<EntidadesCompartidas.Entregas> entregasSeleccionadas)
        {
            return true;
        }

        public List<EntidadesCompartidas.Clientes> ListarClientes()
        {
            return new List<EntidadesCompartidas.Clientes>();
        }

        public List<EntidadesCompartidas.Cadetes> ListarCadetesDisponibles()
        {
            return new List<EntidadesCompartidas.Cadetes>();
        }
        
        public List<EntidadesCompartidas.Turnos> ListarTurnos()
        {
            return new List<EntidadesCompartidas.Turnos>();
        }

        public List<EntidadesCompartidas.Locales> ListarLocales()
        {
            return new List<EntidadesCompartidas.Locales>();
        }

        public bool AltaEntrega(EntidadesCompartidas.Entregas pEntrega)
        {
            return true;
        }
    }
}
