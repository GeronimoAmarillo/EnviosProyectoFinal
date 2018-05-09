using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public interface IControladorPalet
    {

        bool AltaPalet(Palets palet);

        List<Clientes> ListarClientes();

        Galpones BuscarGalpon(int id);

        Palets BuscarPalet(int id);

        bool BajaPalet(int id);
    }
}
