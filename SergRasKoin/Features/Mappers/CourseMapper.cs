using AutoMapper;
using SergRasKoin.Features.DtoModels.Course;
using SergRasKoin.Storage.Models;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.Mappers
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<Course, EditCourse>().ReverseMap();

            CreateMap<CourseDto, Course>().ReverseMap();
        }
    }
}
