using Microsoft.AspNetCore.Mvc;

namespace SergRasKoin.Controllers
{
    [Route("")]
    public class HomeController : Controller 
    {
        public const string Home = "Home";
        public HomeController() 
        { 

        }
        [HttpGet, Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
