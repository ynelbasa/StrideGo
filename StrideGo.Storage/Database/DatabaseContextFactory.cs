using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrideGo.Storage.Database
{
    // For migration purposes, update the connection string accordingly
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=StrideGo.DatabaseDev;MultipleActiveResultSets=False;Integrated Security=True;Connection Timeout=60;");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
