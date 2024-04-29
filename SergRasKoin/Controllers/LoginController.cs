using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SergRasKoin.Features.DtoModels.Login;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Controllers
{
    [Route(Login)]
    public class LoginController : Controller
    {
        private readonly IUserManager userManager;

        public const string Login = "Log";

        public LoginController(IUserManager _userManager)
        {
            userManager = _userManager;
        }

        [HttpGet(nameof(Log), Name = nameof(Log))]
        public IActionResult Log()
        {
            return View();
        }

        [HttpPost(nameof(FindUserAsync), Name = nameof(FindUserAsync))]
        public async Task<ActionResult> FindUserAsync(LoginModel LogMod)
        {
            if (!ModelState.IsValid)
                return View(nameof(Log), LogMod);
            try
                {
                    var user = await userManager.GetUserByMail(LogMod.email);
                    //return RedirectToAction(nameof(ManageController.Sales), "Manage", new { usId = user.IsnNode});
                    return RedirectToAction(nameof(UserMenuController.Menu), "UserMenu", new { usId = user.IsnNode });
                }   
            catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);  
                    return View(nameof(Log), LogMod); 
                }
        }
    }

}
