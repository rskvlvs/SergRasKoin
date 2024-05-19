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
    public interface ICourseService
    {
        IQueryable<Course> GetCourseQueryable(DataContext context, CourseFilterDto filter, bool asNoTracking = true);
    }
}
