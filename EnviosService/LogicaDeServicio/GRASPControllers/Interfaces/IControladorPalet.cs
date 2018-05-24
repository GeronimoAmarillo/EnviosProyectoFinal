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

        bool AltaPalet(Palet palet);

        List<Cliente> ListarClientes();

        Galpon BuscarGalpon(int id);

        Palet BuscarPalet(int id);

        bool BajaPalet(Palet palet);
    }
}
