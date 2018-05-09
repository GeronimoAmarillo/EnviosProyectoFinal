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

        List<Entregas> ListarEntregas();

        bool Entregar(List<Entregas> entregasSelecciondas);

        List<Clientes> ListarClientes();

        List<Cadetes> ListarCadetesDisponibles();

        List<Turnos> ListarTurnos();

        List<Locales> ListarLocales();

        bool AltaEntrega(Entregas pEntrega);
    }
}
