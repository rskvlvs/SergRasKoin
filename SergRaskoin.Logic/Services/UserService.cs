using Microsoft.EntityFrameworkCore;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRaskoin.Logic.Interfaces.Services;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Services
{
    public class UserService : IUserService
    {
		public IQueryable<User> GetUserQueryable(DataContext context, UserFilterDto filter, bool asNoTracking = true)
		{
			IQueryable<User> query = context.Users;

			if (asNoTracking)
			{
				query = query.AsNoTracking();
			}

			return query; 
		}
	}
}
