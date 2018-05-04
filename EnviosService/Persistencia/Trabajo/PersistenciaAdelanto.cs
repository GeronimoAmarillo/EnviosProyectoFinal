using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaAdelanto:IPersistenciaAdelanto
    {
        public List<Adelantos> ListarAdelanto()
        {
            List<Adelantos> list = new List<Adelantos>();
            EnviosEntities Db = new EnviosEntities();
            list = Db.Adelantos.ToList().Where( a => a.Saldado == true).ToList();
            return list;
        }
    }
}
