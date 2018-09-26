using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using Microsoft.EntityFrameworkCore;

namespace PersistenciaCore
{
    class PersistenciaEntrega:IPersistenciaEntrega
    {
        public bool Entregar(List<EntidadesCompartidasCore.Entrega> entregas)
        {
            return true;
        }

        public List<EntidadesCompartidasCore.Entrega> ListarEntregas()
        {
            return new List<EntidadesCompartidasCore.Entrega>();
        }

        public List<Paquetes> TransformarPaquetes(List<Paquete> pPaquetes)
        {
            try
            {
                List<Paquetes> paquetesR = new List<Paquetes>();

                foreach (Paquete p in pPaquetes)
                {
                    Paquetes pN = new Paquetes();

                    pN.Cliente = p.Cliente;
                    pN.Entrega = p.Entrega;
                    pN.Estado = p.Estado;
                    pN.FechaSalida = p.FechaSalida;
                    pN.NumReferencia = p.NumReferencia;
                    pN.Ubicacion = p.Ubicacion;

                    paquetesR.Add(pN);
                }

                return paquetesR;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al transformar los paquetes.");
            }
        }

        public bool AltaEntrega(EntidadesCompartidasCore.Entrega entrega)
        {
            try
            {
                PersistenciaCore.Entregas entregaAgregar = new PersistenciaCore.Entregas();

                entregaAgregar.ClienteEmisor = entrega.ClienteEmisor;
                entregaAgregar.ClienteReceptor = entrega.ClienteReceptor;
                entregaAgregar.Codigo = entrega.Codigo;
                entregaAgregar.Fecha = entrega.Fecha;
                entregaAgregar.LocalEmisor = entrega.LocalEmisor;
                entregaAgregar.LocalReceptor = entrega.LocalReceptor;
                entregaAgregar.NombreReceptor = entrega.NombreReceptor;
                entregaAgregar.Paquetes = TransformarPaquetes(entrega.Paquetes);
                entregaAgregar.Paquetes1 = TransformarPaquetes(entrega.Paquetes1);
                entregaAgregar.Turno = entrega.Turno;


                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Entregas.Add(entregaAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta la entrega.");
            }
        }
    }
}
