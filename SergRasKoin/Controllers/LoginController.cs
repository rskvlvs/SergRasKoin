using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SergRasKoin.Features.DtoModels.Login;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Controllers
{
    //Контроллер для страницы входа в аккаунт пользователя
    [Route(Login)]
    public class LoginController : Controller
    {
        private readonly IUserManager userManager;

        public const string Login = "Log";

        //Контсруктор задаем userManager
        public LoginController(IUserManager _userManager)
        {
            userManager = _userManager;
        }

        //Прописал, чтобы адекватно выводил вид
        [HttpGet(nameof(Log), Name = nameof(Log))]
        public IActionResult Log()
        {
            return View();
        }

        //Метод поискка пользователя по его email
        [HttpPost(nameof(FindUserAsync), Name = nameof(FindUserAsync))]
        public async Task<ActionResult> FindUserAsync(LoginModel LogMod)
        {
            if (!ModelState.IsValid)
                return View(nameof(Log), LogMod);
            try
                {
                    var user = await userManager.GetUserByMail(LogMod.email);
                if (user == null) throw new Exception("Пользователь не найден"); 
                    //return RedirectToAction(nameof(ManageController.Sales), "Manage", new { usId = user.IsnNode});
                    return RedirectToAction(nameof(UserMenuController.Menu), "UserMenu", new { usId = user.IsnNode, name = user.Name, surname = user.Surname});
                }   
            catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);  
                    return View(nameof(Log), LogMod); 
                }
        }
    }

}
