using Microsoft.EntityFrameworkCore;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRasKoin.Storage.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Sales> Sale { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Course> Courses { get; set; }
    }
}
