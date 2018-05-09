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
        List<Vehiculos> ListarVehiculos();

        Vehiculos SeleccionarVehiculo(string matricula);

        bool RegistrarMulta(Multas pMulta);
    }
}
