using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorMulta
    {
        void IniciarRegistroMulta();

        List<DTVehiculo> ListarVehiculos();

        DTVehiculo SeleccionarVehiculo(string matricula);

        Multas GetMulta();

        void SetMulta(Multas pMulta);

        void SetVehiculo(Vehiculos pVehiculo);

        List<Vehiculos> GetVehiculos();

        bool RegistrarMulta(DTMulta pMulta);
    }
}
