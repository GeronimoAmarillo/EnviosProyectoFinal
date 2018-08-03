using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorVehiculo
    {

        List<Cadete> ListarCadetesDisponibles();

        bool ModificarVehiculo(Vehiculo pVehiculo);

        Cadete SeleccionarCadete(int ci);

        Cadete BuscarEmpleado(int ci);

        bool BajaVehiculo(Vehiculo vehiculo);

        Vehiculo BuscarVehiculo(string matricula);

        bool AltaVehiculo(Vehiculo pVehiculo);

        bool ExisteVehiculo(string matricula);

        List<Vehiculo> ListarVehiculos();
    }
}
