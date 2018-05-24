using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    class ControladorVehiculo: IControladorVehiculo
    {
        private Vehiculos vehiculo;
        private string matricula;
        private List<Cadetes> cadetesDisponibles;

        public Vehiculos GetVehiculo()
        {
            return vehiculo;
        }

        public void SetMatricula(string matricula)
        {
            vehiculo.Matricula = matricula;
        }

        public List<DTCadete> ListarCadetesDisponibles()
        {
            return new List<DTCadete>();
        }

        public Cadetes GetCadete()
        {
            return vehiculo.Cadetes;
        }

        public string GetMatricula()
        {
            return matricula;
        }

        public bool ModificarVehiculo(DTVehiculo pVehiculo)
        {
            return true;
        }

        public DTCadete SeleccionarCadete(int ci)
        {
            return new DTCadete();
        }

        public List<Cadetes> GetCadetes()
        {
            return new List<Cadetes>();
        }

        public void SetCadetes(List<Cadetes> pCadetesDisponibles)
        {
            cadetesDisponibles = pCadetesDisponibles;
        }

        public void SetVehiculo(Vehiculos pVehiculo)
        {
            vehiculo = pVehiculo;
        }

        public bool EliminarVehiculo(Vehiculos vehiculo)
        {
            return true;
        }

        public DTVehiculo BuscarVehiculo(string matricula)
        {
            return new DTVehiculo();
        }

        public DTVehiculo ContemplarTipo()
        {
            return new DTVehiculo();
        }

        public bool AltaVehiculo(DTVehiculo pVehiculo)
        {
            return true;
        }

        public bool ExisteVehiculo(string matricula)
        {
            return true;
        }
    }
}
