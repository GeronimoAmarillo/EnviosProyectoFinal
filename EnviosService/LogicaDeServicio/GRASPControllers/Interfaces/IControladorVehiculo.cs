using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorVehiculo
    {

        List<Cadetes> ListarCadetesDisponibles();

        bool ModificarVehiculo(Vehiculos pVehiculo);

        Cadetes SeleccionarCadete(int ci);

        Cadetes BuscarEmpleado(int ci);

        bool BajaVehiculo(Vehiculos vehiculo);

        Vehiculos BuscarVehiculo(string matricula);

        bool AltaVehiculo(Vehiculos pVehiculo);

        bool ExisteVehiculo(string matricula);
    }
}
