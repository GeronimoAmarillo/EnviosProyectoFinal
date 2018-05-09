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
      
        public Paquetes BuscarPaquete(int codigo)
        {
            return new Paquetes();
        }
        
        public List<Locales> ListarLocales()
        {
            return new List<Locales>();
        }

        public List<Paquetes> ListarPaquetesEnviadosXCliente(int cedula)
        {
            return new List<Paquetes>();
        }
        

        public List<Paquetes> ListarPaquetesRecibidosXCliente(int cedula)
        {
            return new List<Paquetes>();
        }

        public Locales BuscarLocal(string nombre)
        {
            return new Locales();
        }
    }
}
