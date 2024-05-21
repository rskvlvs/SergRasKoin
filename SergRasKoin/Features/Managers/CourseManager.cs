using AutoMapper;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRaskoin.Logic.Interfaces.Services;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System.Globalization;

namespace SergRasKoin.Features.Managers
{
    public class CourseManager : ICourseManager
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseService _courseService;
        private readonly DataContext _dataContext;

        public CourseManager(IMapper mapper, ICourseRepository courseRepository, ICourseService courseService, DataContext dataContext)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseService = courseService;
            _dataContext = dataContext;
        }

        public Course UpdateCourse()
        {
            Course course = new Course()
            {
                course = _courseRepository.CalculateCourse(_courseRepository.GetSumOfAllSales(_dataContext)),
                dateTime = DateTime.Now,
                Isnnode = Guid.NewGuid()
            };
            _courseRepository.UpdateCourse(_dataContext, course);
            _dataContext.SaveChanges();
            return course;
        }

        public Course GetLastCourse()
        {
            Course course = _courseRepository.GetLastCourse(_dataContext);

            return course;
        }
    }
}
