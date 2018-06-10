using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorVehiculo
    {
        Vehiculo GetVehiculo();

        void SetMatricula(string matricula);

        List<Cadete> ListarCadetesDisponibles();

        Cadete GetCadete();

        string GetMatricula();

        bool ModificarVehiculo(Vehiculo pVehiculo);

        Cadete SeleccionarCadete(int ci);

        List<Cadete> GetCadetes();

        void SetCadetes(List<Cadete> pCadetesDisponibles);

        void SetVehiculo(Vehiculo pVehiculo);

        bool EliminarVehiculo(Vehiculo vehiculo);

        Vehiculo BuscarVehiculo(string matricula);

        Vehiculo ContemplarTipo();

        bool AltaVehiculo(Vehiculo pVehiculo);

        bool ExisteVehiculo(string matricula);
    }
}
