using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaApps
    {
        public static  GetLogicaNoticia()
        {
            return (LogicaNoticia.GetInstancia());
        }

        public static ILogicaPeriodista GetLogicaPeriodista()
        {
            return (LogicaPeriodista.GetInstancia());
        }

        public static ILogicaUsuario GetLogicaUsuario()
        {
            return (LogicaUsuario.GetInstancia());
        }
    }
}
