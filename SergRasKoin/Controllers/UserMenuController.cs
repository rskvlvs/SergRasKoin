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

        [HttpGet(nameof(Menu), Name = nameof(Menu))]
        public async Task<ActionResult> Menu(Guid usId)
        {
            var menuModel = new MenuModel() { UserId = usId };
            return View(UserMenu, menuModel);
        }

        [HttpPost(nameof(UserOperation), Name = nameof(UserOperation))]
        public IActionResult UserOperation(MenuModel menuModel)
        {
            if(menuModel.operation.IsNullOrEmpty()) return View(nameof(UserOperation), menuModel);
            if (menuModel.operation == "К покупкам")
            {
                try
                {
                    return RedirectToAction(nameof(ManageController.Sales), "Manage", new { usId = menuModel.UserId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(nameof(UserOperation), menuModel);
                }
            }
            else if(menuModel.operation == "Получить сумму коинов")
            {
                try
                {
                    return RedirectToAction(nameof(ManageController.GetSumSalesAsync), "Manage", new { usId = menuModel.UserId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(nameof(UserOperation), menuModel);
                }
            }
            return View(nameof(UserOperation), menuModel);
        }
    }
}
