using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Interfaces.Repositories
{
    public interface ISalesRepository
    {
        Sales Create(DataContext context, Sales sales);

        public Sales Update(DataContext context, Sales sales);

        void Delete(DataContext context, Guid isnNode);

        Sales GetById(DataContext context, Guid isnNode);

        long GetSumSales(DataContext context, Guid? usId);

    }
}
