using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorMulta
    {
        List<Vehiculo> ListarVehiculos();

        Vehiculo SeleccionarVehiculo(string matricula);

        bool RegistrarMulta(Multa pMulta);
    }
}
