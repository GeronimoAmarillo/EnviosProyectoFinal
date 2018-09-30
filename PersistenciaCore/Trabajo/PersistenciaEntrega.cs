using System;
using System.Collections.Generic;
using System.Globalization;
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
                var optionsBuilder = new DbContextOptionsBuilder<EnviosContext>();

                optionsBuilder.UseSqlServer(Conexion.ConnectionString);


                PersistenciaCore.Entregas entregaAgregar = new PersistenciaCore.Entregas();

                entregaAgregar.ClienteEmisor = entrega.ClienteEmisor;
                entregaAgregar.ClienteReceptor = entrega.ClienteReceptor;
                entregaAgregar.Codigo = entrega.Codigo;
                entregaAgregar.Fecha = entrega.Fecha;
                entregaAgregar.LocalEmisor = entrega.LocalEmisor;
                entregaAgregar.LocalReceptor = entrega.LocalReceptor;
                entregaAgregar.NombreReceptor = entrega.NombreReceptor;


                int codigo = 0;

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    bool existe = true;

                    while (existe == true)
                    {
                        codigo = GenerarCodigo();

                        existe = dbConnection.Entregas.Where(x => x.Codigo == codigo).Any();
                    }

                }

                entregaAgregar.Codigo = codigo;

                if(entrega.Paquetes != null)
                {
                    foreach (Paquete p in entrega.Paquetes)
                    {
                        p.Entrega = codigo;
                    }

                    entregaAgregar.Paquetes = TransformarPaquetes(entrega.Paquetes);
                }

                if (entrega.Paquetes1 != null)
                {
                    foreach (Paquete p in entrega.Paquetes1)
                    {
                        p.Entrega = codigo;
                    }

                    entregaAgregar.Paquetes1 = TransformarPaquetes(entrega.Paquetes1);
                }

                entregaAgregar.Turno = entrega.Turno;

                using (EnviosContext dbConnection = new EnviosContext(optionsBuilder.Options))
                {
                    dbConnection.Entregas.Add(entregaAgregar);
                    dbConnection.SaveChanges();

                    return true;
                }

                entregaAgregar.Turno = entrega.Turno;

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

        public int GenerarCodigo()
        {
            try
            {
                const string valid = "1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                int charNum = 1;
                while (charNum < 11)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                    charNum++;
                }

                return Convert.ToInt32(res.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede convertir el codigo generado.");
            }
        }
    }
}
