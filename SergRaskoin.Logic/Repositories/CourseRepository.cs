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
    public class CourseRepository : ICourseRepository
    {
        public Course UpdateCourse(DataContext context, Course course)
        {
            context.Courses.Add(course);

            return course;
        }

    }
}
