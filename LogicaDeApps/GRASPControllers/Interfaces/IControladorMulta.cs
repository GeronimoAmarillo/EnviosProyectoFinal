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

        Multa GetMulta();

        void SetMulta(Multa pMulta);

        void SetVehiculo(Vehiculo pVehiculo);

        List<Vehiculo> GetVehiculos();

        bool RegistrarMulta(DTMulta pMulta);
    }
}
