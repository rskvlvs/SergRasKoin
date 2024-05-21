using Microsoft.AspNetCore.Mvc;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRaskoin.Logic.Interfaces.Services;
using SergRasKoin.Features.DtoModels.Home;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        //Не дает записать в Route путь Home
        //public const string Home = "Home";

        public readonly ICourseManager _courseManager;

        public HomeController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        //Не дает так прописать HttpGet
        //[HttpGet(nameof(Index), Name = nameof(Index))]
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            Course course = _courseManager.GetLastCourse();
            HomeModel model;
            if(course != null)
                model = new HomeModel() { course = course.course };
            else
                model = new HomeModel() { course = 0 };
            return View(model);
        }
    }
}
