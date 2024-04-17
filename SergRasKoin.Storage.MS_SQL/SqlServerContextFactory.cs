using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SergRasKoin.Storage.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRasKoin.Storage.MS_SQL
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private const string DbContextString = "Server=localhost,1433;Database=SergRasKoinDb;User ID=sa;Password=sjfkdjFDF!so12fjks;MultipleActiveResultSets=true;TrustServerCertificate=True";
        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            optionBuilder.UseSqlServer(DbContextString, b => b.MigrationsAssembly(typeof(SqlServerContextFactory).Namespace));
            return new DataContext(optionBuilder.Options);
        }
    }
}
