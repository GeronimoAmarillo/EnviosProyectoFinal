using PersistenciaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaCore
{
    public class FabricaPersistencia
    {

        public static IPersistenciaAdelanto GetPersistenciaAdelanto()
        {
            return new PersistenciaAdelanto();
        }

        public static IPersistenciaBalance GetPersistenciaBalance()
        {
            return new PersistenciaBalance();
        }

        public static IPersistenciaCalificacion GetPersistenciaCalificacion()
        {
            return new PersistenciaCalificacion();
        }

        public static IPersistenciaCliente GetPersistenciaCliente()
        {
            return new PersistenciaCliente();
        }

        public static IPersistenciaPaquete GetPersistenciaPaquete()
        {
            return new PersistenciaPaquete();
        }

        public static IPersistenciaAdministrador GetPersistenciaAdministrador()
        {
            return new PersistenciaAdministrador();
        }

        public static IPersistenciaEntrega GetPersistenciaEntrega()
        {
            return new PersistenciaEntrega();
        }

        public static IPersistenciaGasto GetPersistenciaGasto()
        {
            return new PersistenciaGasto();
        }

        public static IPersistenciaImpuesto GetPersistenciaImpuesto()
        {
            return new PersistenciaImpuesto();
        }

        public static IPersistenciaIngreso GetPersistenciaIngreso()
        {
            return new PersistenciaIngreso();
        }

        public static IPersistenciaLocal GetPersistenciaLocal()
        {
            return new PersistenciaLocal();
        }

        public static IPersistenciaMulta GetPersistenciaMulta()
        {
            return new PersistenciaMulta();
        }

        public static IPersistenciaPalet GetPersistenciaPalet()
        {
            return new PersistenciaPalet();
        }

        public static IPersistenciaCadete GetPersistenciaCadete()
        {
            return new PersistenciaCadete();
        }

        public static IPersistenciaAuto GetPersistenciaAuto()
        {
            return new PersistenciaAuto();
        }

        public static IPersistenciaReparacion GetPersistenciaReparacion()
        {
            return new PersistenciaReparacion();
        }

        public static IPersistenciaCamion GetPersistenciaCamion()
        {
            return new PersistenciaCamion();
        }

        public static IPersistenciaTurno GetPersistenciaTurno()
        {
            return new PersistenciaTurno();
        }

        public static IPersistenciaCamioneta GetPersistenciaCamioneta()
        {
            return new PersistenciaCamioneta();
        }

        public static IPersistenciaMoto GetPersistenciaMoto()
        {
            return new PersistenciaMoto();
        }
        

    }
}
