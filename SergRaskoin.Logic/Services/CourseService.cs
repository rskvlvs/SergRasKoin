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
    public class CourseService : ICourseService
    {
        public IQueryable<Course> GetCourseQueryable (DataContext context, CourseFilterDto filter, bool asNoTracking = true)
        {
            IQueryable<Course> query = context.Courses;
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if(!string.IsNullOrEmpty(Convert.ToString(filter.course)))
                query = query.Where(x => x.course == filter.course);

            return query;
        }

    }
}
