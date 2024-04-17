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
    public interface IUserService
    {
		IQueryable<User> GetUserQueryable(DataContext context, UserFilterDto filter, bool asNoTracking = true);

	}
}
