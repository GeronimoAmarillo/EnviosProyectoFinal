using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    class ControladorPaquete:IControladorPaquete
    {
        public bool RealizarReclamo(string descripcion)
        {
            return true;
        }
      
        public Paquete BuscarPaquete(int codigo)
        {
            return new Paquete();
        }
        
        public List<Local> ListarLocales()
        {
            return new List<Local>();
        }

        public List<Paquete> ListarPaquetesEnviadosXCliente(int cedula)
        {
            return new List<Paquete>();
        }
        

        public List<Paquete> ListarPaquetesRecibidosXCliente(int cedula)
        {
            return new List<Paquete>();
        }

        public Local BuscarLocal(string nombre)
        {
            return new Local();
        }
    }
}
