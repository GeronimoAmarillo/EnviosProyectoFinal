using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorEntrega
    {

        List<Entrega> ListarEntregas();

        bool Entregar(List<Entrega> entregasSelecciondas);

        List<Cliente> ListarClientes();

        List<Cadete> ListarCadetesDisponibles();

        List<Turno> ListarTurnos();

        List<Local> ListarLocales();

        bool AltaEntrega(Entrega pEntrega);
    }
}
