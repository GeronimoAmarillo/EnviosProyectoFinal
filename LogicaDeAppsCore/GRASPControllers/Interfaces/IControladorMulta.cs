using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeAppsCore
{
    public interface IControladorMulta
    {
        void IniciarRegistroMulta();

        List<Vehiculo> ListarVehiculos();

        Vehiculo SeleccionarVehiculo(string matricula);

        Multa GetMulta();

        void SetMulta(Multa pMulta);

        void SetVehiculo(Vehiculo pVehiculo);

        List<Vehiculo> GetVehiculos();

        bool RegistrarMulta(Multa pMulta);
    }
}
