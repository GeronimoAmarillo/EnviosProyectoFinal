using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PersistenciaCore
{
    class ApplicationDbContextFactory: IDesignTimeDbContextFactory<EnviosContext>
    {

        public EnviosContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EnviosContext>();
            builder.UseSqlServer(Conexion.ConnectionString,
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(EnviosContext).GetTypeInfo().Assembly.GetName().Name));

            return new EnviosContext(builder.Options);
        }

    }
}
