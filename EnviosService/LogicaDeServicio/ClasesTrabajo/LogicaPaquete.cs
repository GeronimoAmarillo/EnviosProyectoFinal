using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;

namespace LogicaDeServicio
{
    public class LogicaPaquete
    {
        public bool AltaPaquete(Paquetes unPaquete)
        {
            bool exito = false;
            return exito;
        }

        public Paquetes BuscarPaqueteXreferencia(int numeroReferencia)
        {
            Paquetes paquete = new Paquetes();
            return paquete;
        }

        public Paquetes BuscarPaqueteXcodigo(int codigo)
        {
            Paquetes paquete = new Paquetes();
            return paquete;
        }

        public List<Paquetes> ListarPaquetesEnviadosXcliente(int cedula)
        {
            List<Paquetes> lista = new List<Paquetes>();
            return lista;
        }

        public List<Paquetes> ListarPaquetesRecibidosXcliente(int cedula)
        {
            List<Paquetes> lista = new List<Paquetes>();
            return lista;
        }

        public bool RealizarReclamo(string descripcion)
        {
            bool exito = false;
            return exito;
        }
    }
}
