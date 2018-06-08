using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorReparacion
    {
        Reparacion GetReparacion();

        void SetReparacion(Reparacion pReparacion);

        bool RegistrarReparacion(Reparacion reparacion);

        List<Vehiculo> ListarVehiculos();

        Vehiculo SeleccionarVehiculo(string matricula);

        void IniciarRegistroReparacion();


    }
}
