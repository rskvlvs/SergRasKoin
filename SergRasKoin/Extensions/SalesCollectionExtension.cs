using SergRaskoin.Logic.Extensions;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Features.Manager;
using SergRasKoin.Features.Managers;

namespace SergRasKoin.Extensions
{
    public static class SalesCollectionExtension
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddLogicServices();

            services.AddTransient<ISalesManager, SalesManager>();

            services.AddTransient<IUserManager, UserManager>();

            services.AddTransient<ICourseManager, CourseManager>();
        }
    }
}
