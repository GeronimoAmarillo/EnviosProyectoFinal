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
        Vehiculos GetVehiculo();

        void SetMatricula(string matricula);

        List<DTCadete> ListarCadetesDisponibles();

        Cadetes GetCadete();

        string GetMatricula();

        bool ModificarVehiculo(DTVehiculo pVehiculo);

        DTCadete SeleccionarCadete(int ci);

        List<Cadetes> GetCadetes();

        void SetCadetes(List<Cadetes> pCadetesDisponibles);

        void SetVehiculo(Vehiculos pVehiculo);

        bool EliminarVehiculo(Vehiculos vehiculo);

        DTVehiculo BuscarVehiculo(string matricula);

        DTVehiculo ContemplarTipo();

        bool AltaVehiculo(DTVehiculo pVehiculo);

        bool ExisteVehiculo(string matricula);
    }
}
