using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    public interface IControladorPalet
    {

        bool AltaPalet(Palet palet);

        List<Cliente> ListarClientes();

        Galpon BuscarGalpon(int id);

        Palet BuscarPalet(int id);

        List<Palet> ListarPalets();

        bool BajaPalet(int id);

        List<Palet> ListarPaletsTodos();
    }
}
