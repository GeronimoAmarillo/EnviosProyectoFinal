using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidasCore;

namespace LogicaDeServicioCore
{
    class ControladorMulta:IControladorMulta
    {
        public List<Vehiculo> ListarVehiculos()
        {
            return new List<Vehiculo>();
        }

        public Vehiculo SeleccionarVehiculo(string matricula)
        {
            return new Vehiculo();
        }

        public bool RegistrarMulta(Multa pMulta)
        {
            try
            {
                return LogicaMulta.RegistrarMulta(pMulta);
            }
            catch(Exception ex)
            {
                throw new Exception("Error al inentar registrar la multa. " + ex.Message);
            }
            
        }
    }
}
