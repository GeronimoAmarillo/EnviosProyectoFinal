using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    class ControladorVehiculo: IControladorVehiculo
    {
        private Vehiculo vehiculo;
        private string matricula;
        private List<Cadete> cadetesDisponibles;

        public Vehiculo GetVehiculo()
        {
            return vehiculo;
        }

        public void SetMatricula(string matricula)
        {
            vehiculo.Matricula = matricula;
        }

        public List<Cadete> ListarCadetesDisponibles()
        {
            return new List<Cadete>();
        }

        public Cadete GetCadete()
        {
            return vehiculo.Cadetes;
        }

        public string GetMatricula()
        {
            return matricula;
        }

        public bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            return true;
        }

        public Cadete SeleccionarCadete(int ci)
        {
            return new Cadete();
        }

        public List<Cadete> GetCadetes()
        {
            return new List<Cadete>();
        }

        public void SetCadetes(List<Cadete> pCadetesDisponibles)
        {
            cadetesDisponibles = pCadetesDisponibles;
        }

        public void SetVehiculo(Vehiculo pVehiculo)
        {
            vehiculo = pVehiculo;
        }

        public bool EliminarVehiculo(Vehiculo vehiculo)
        {
            return true;
        }

        public Vehiculo BuscarVehiculo(string matricula)
        {
            return new Vehiculo();
        }

        public Vehiculo ContemplarTipo()
        {
            return new Vehiculo();
        }

        public bool AltaVehiculo(Vehiculo pVehiculo)
        {
            return true;
        }

        public bool ExisteVehiculo(string matricula)
        {
            return true;
        }
    }
}
