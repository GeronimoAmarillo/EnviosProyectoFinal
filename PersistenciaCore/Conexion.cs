using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenciaCore
{
    public class Conexion
    {
        private static string connectionString = "data source=(localdb)\\MSSQLLocalDB;initial catalog=EnviosContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public string  ConnectionString
        {
            get { return connectionString; }
        }
    }
}
