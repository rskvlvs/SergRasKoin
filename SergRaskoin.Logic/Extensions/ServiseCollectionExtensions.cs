using Microsoft.Extensions.DependencyInjection;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRaskoin.Logic.Interfaces.Services;
using SergRaskoin.Logic.Repositories;
using SergRaskoin.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Extensions
{
    public static class ServiseCollectionExtensions
    {
        public static void AddLogicServices(this IServiceCollection services)
        {
            services.AddSingleton<ISalesService, SalesService>();
            services.AddSingleton<IUserService, UserService>();

            services.AddSingleton<ISalesRepository, SalesRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

        }
    }
}
