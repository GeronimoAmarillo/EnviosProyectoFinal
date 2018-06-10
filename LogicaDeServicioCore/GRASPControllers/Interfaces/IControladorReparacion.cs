using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorReparacion
    {

        bool RegistrarReparacion(Reparacion reparacion);

        List<Vehiculo> ListarVehiculos();

        Vehiculo SeleccionarVehiculo(string matricula);
    }
}
