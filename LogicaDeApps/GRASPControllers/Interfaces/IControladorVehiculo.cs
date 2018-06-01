using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorVehiculo
    {
        Vehiculo GetVehiculo();

        void SetMatricula(string matricula);

        List<DTCadete> ListarCadetesDisponibles();

        Cadete GetCadete();

        string GetMatricula();

        bool ModificarVehiculo(DTVehiculo pVehiculo);

        DTCadete SeleccionarCadete(int ci);

        List<Cadete> GetCadetes();

        void SetCadetes(List<Cadete> pCadetesDisponibles);

        void SetVehiculo(Vehiculo pVehiculo);

        bool EliminarVehiculo(Vehiculo vehiculo);

        DTVehiculo BuscarVehiculo(string matricula);

        DTVehiculo ContemplarTipo();

        bool AltaVehiculo(DTVehiculo pVehiculo);

        bool ExisteVehiculo(string matricula);
    }
}
