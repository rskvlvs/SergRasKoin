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
        //public Course UpdateCourse(DataContext context, Course course)
        //{
        //    context.Courses.Add(course);

        //    return course;
        //}
        public long GetSumOfAllSales(DataContext context)
        {
            var Sales = context.Sale;

            long totalSalesAmount = (long)(Sales.Sum(x => x.Count_Of_Coins));

            return totalSalesAmount;
        }
        public double CalculateCourse(long sum_of_sales)
        {
            double new_course = (Math.Abs(sum_of_sales) * 0.0001);
            return new_course;
        }

        public Course UpdateCourse(DataContext context, Course course)
        {
            context.Add(course);

            return course;
        }

        public Course GetLastCourse(DataContext context)
        {
            Course latestCourse = context.Courses
                                  .OrderByDescending(c => c.dateTime)
                                  .FirstOrDefault();
            return latestCourse;

        }
    }
}
