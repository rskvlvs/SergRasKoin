using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SergRasKoin.Features.DtoModels.UserMenu;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Controllers
{
    [Route(UserMenu)]
    public class UserMenuController : Controller
    {
        public const string UserMenu = "UserMenu";
        public ISalesManager salesManager;

        public UserMenuController(ISalesManager _salesManager)
        {
            salesManager = _salesManager;
        }

        //Выводит View
        [HttpGet(nameof(Menu), Name = nameof(Menu))]
        public async Task<ActionResult> Menu(Guid usId, string name, string surname)
        {
            var menuModel = new MenuModel() { UserId = usId, UserName = name, UserSurname = surname};
            return View(UserMenu, menuModel);
        }
        
        //Переводит пользователя на разные страницы в зависимости от выбранного действия
        [HttpPost(nameof(UserOperation), Name = nameof(UserOperation))]
        public IActionResult UserOperation(MenuModel menuModel)
        {
            try
            {
                if (menuModel.operation.IsNullOrEmpty()) throw (new Exception());
                if (menuModel.operation == "К покупкам")
                {
                    try
                    {
                        return RedirectToAction(nameof(ManageController.Sales), "Manage", new { usId = menuModel.UserId });
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(nameof(Menu), menuModel.UserId);
                    }
                }
                else if (menuModel.operation == "Баланс пользователя")
                {
                    try
                    {
                        return RedirectToAction(nameof(ManageController.GetSumSalesAsync), "Manage", new { usId = menuModel.UserId });
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(nameof(Menu), menuModel.UserId);
                    }
                }
                else if (menuModel.operation == "Продать SergRaskoin")
                {
                    try
                    {
                        return RedirectToAction(nameof(ManageController.SaleUserCoinsView), "Manage", new {usId = menuModel.UserId});
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(nameof(Menu), menuModel.UserId);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError (string.Empty, ex.Message);
                return View(nameof(UserOperation), menuModel);
            }
            return View(nameof(Menu), menuModel.UserId);
        }
    }
}
