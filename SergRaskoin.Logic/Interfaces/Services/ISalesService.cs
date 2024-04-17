using Microsoft.EntityFrameworkCore;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Interfaces.Services
{
    public interface ISalesService
    {
        IQueryable<Sales> GetSalesQueryable(DataContext context, SalesFilterDto filter, bool asNoTracking = true);
    }
}
