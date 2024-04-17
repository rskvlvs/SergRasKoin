using Microsoft.EntityFrameworkCore;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRaskoin.Logic.Interfaces.Services;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Services
{
    public class SalesService : ISalesService
    {
        public IQueryable<Sales> GetSalesQueryable(DataContext context, SalesFilterDto filter, bool asNoTracking = true)
        {
            IQueryable<Sales> query = context.Sale;

            if (asNoTracking)
            {
                query = query.AsNoTracking(); 
            }

            //Разобраться с тем, для чего  у него описано поле код и могу ли я описать это так!!!
            if (!string.IsNullOrEmpty(Convert.ToString(filter.Count_Of_Coins)))
                query = query.Where(x => x.Count_Of_Coins == filter.Count_Of_Coins);

            //Нужно будет дописать запрос
            return query;
        }
    }
}
