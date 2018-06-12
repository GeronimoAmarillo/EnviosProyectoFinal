using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenciaCore
{
    public class Conexion
    {
        //private static string connectionString = "Data Source=DESKTOP-HT1MEQ7;Integrated Security=false;database=EnviosContext;User ID=EnviosDBManager;Password=EnviosService;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static string connectionString = "Data Source=BLACKBIRD2\\SQLEXPRESS;Integrated Security=false;database=EnviosContext;User ID=EnviosDBManager;Password=EnviosService;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string  ConnectionString
        {
            get { return connectionString; }
        }
    }
}
