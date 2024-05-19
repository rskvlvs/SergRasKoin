using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Course UpdateCourse(DataContext context, Course course);
    }
}
