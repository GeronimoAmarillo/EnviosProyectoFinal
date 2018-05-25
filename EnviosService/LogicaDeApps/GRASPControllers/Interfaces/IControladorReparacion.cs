using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorReparacion
    {
        Reparacion GetReparacion();

        void SetReparacion(Reparacion pReparacion);

        bool RegistrarReparacion(DTReparacion reparacion);

        List<DTVehiculo> ListarVehiculos();

        DTVehiculo SeleccionarVehiculo(string matricula);

        void IniciarRegistroReparacion();


    }
}
