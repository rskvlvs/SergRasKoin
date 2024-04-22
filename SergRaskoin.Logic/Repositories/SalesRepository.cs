﻿using Microsoft.EntityFrameworkCore;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Repositories
{
    public class SalesRepository : ISalesRepository
    {

        public Sales Create(DataContext context, Sales sales)
        {
            //sales.IsnNode = Guid.NewGuid();
            context.Sale.Add(sales);

            return sales;
        }
        public Sales Update(DataContext context, Sales sales)
        {
            var salesDb = context.Sale.FirstOrDefault(x => x.IsnNode == sales.IsnNode)
                ?? throw new Exception($"Продажа с идентификатором {sales.IsnNode} не найдена");

            salesDb.Count_Of_Coins = sales.Count_Of_Coins;

            return salesDb;
        }

        public void Delete(DataContext context, Guid isnNode)
        {
            var salesDb = context.Sale.FirstOrDefault(x => x.IsnNode == isnNode)
               ?? throw new Exception($"Продажа с идентификатором {isnNode} не найдена");

            context.Sale.Remove(salesDb);

        }
        public Sales GetById(DataContext context, Guid isnNode)
        {
            var salesDb = context.Sale.AsNoTracking().FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Продажа с идентификатором {isnNode} не найдена");

            return salesDb;
        }
    }
}
