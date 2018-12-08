using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorEntrega
    {

        List<Entrega> ListarEntregas();

        bool Entregar(EntidadesCompartidasCore.Entrega entrega);

        List<Cliente> ListarClientes();

        List<Cadete> ListarCadetesDisponibles();

        List<Turno> ListarTurnos();

        List<Local> ListarLocales();

        Entrega BuscarEntrega(int codigo);

        bool AsignarEntrega(EntidadesCompartidasCore.Entrega pEntrega);

        bool LevantarEntrega(EntidadesCompartidasCore.Entrega pEntrega);
    }
}
