using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;
using PersistenciaCore;

namespace LogicaDeServicioCore
{
    public class LogicaMulta
    {
        public static bool RegistrarMulta(Multa multa)
        {
            try
            {
                bool exito = FabricaPersistencia.GetPersistenciaMulta().RegistrarMulta(multa);

                if (exito)
                {
                    Gasto gasto = new Gasto
                    {
                        Id = 0,
                        Descripcion = "Multa: " + multa.Motivo,
                        Extra = true,
                        Suma = multa.Suma,
                        fechaRegistro = DateTime.Now
                    };

                    FabricaPersistencia.GetPersistenciaGasto().RegistrarGasto(gasto);

                }

                return exito;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar dar de alta la multa." + ex.Message);
            }
        }
    }
}
