using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using LogicaDeApps.Models;

namespace LogicaDeApps
{
    public interface IControladorPaquete
    {
        bool RealizarReclamo(string descripcion);

        Paquetes GetPaquete();

        DTPaquete BuscarPaquete(int codigo);

        void SetPaquete(Paquetes pPaquete);

    }
}
