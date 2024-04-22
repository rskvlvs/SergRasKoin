using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SergRasKoin.Features.DtoModels.Sales;
using SergRasKoin.Features.Interfaces.Managers;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRasKoin.Features.DtoModels.User;

namespace SergRasKoin.Controllers
{
    [Route(Registration)]
    public class RegistrationController : Controller
    {
        public const string Registration = "Registration"; 

        private readonly IUserManager _userManager;
        public RegistrationController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet(nameof(User), Name = nameof(User))]
        public async Task<ActionResult> User()
        {
            //Какая-то ошибка при создании, тк передаю Dto во View, а надо Edit
            //var user = _userManager.GetListUser(new UserFilterDto()).FirstOrDefault();
            //return View(user);
            return View();
        }

        [HttpGet(nameof(CreateUser))]
        public IActionResult CreateUser(Guid userId)
        {
            return View();
        }

        [HttpPut(nameof(UpdateUser), Name = nameof(UpdateUser))]
        public async Task<ActionResult> UpdateUser([FromBody] EditUser user)
        {
            _userManager.Update(user);
            return Ok();
        }

        [HttpPost(nameof(CreateUserView), Name = nameof(CreateUserView))]
        public async Task<ActionResult> CreateUserView(EditUser user)
        {
            if (!ModelState.IsValid)
                return View(nameof(User), user);

            var usId = _userManager.Create(user);
            //return RedirectToAction(nameof(GetListUser));

            //Так не сохраняет айдишник
            return RedirectToAction("Sales", "Manage", new {usId});

            //Пробую вызывать другую функцию (выдает ошибку при загрузке страницы
            //return RedirectToAction(nameof(ManageController.CreateSalesView), "Manage", new { usId });
        }

        [HttpPut(nameof(DeleteUser), Name = nameof(DeleteUser))]
        public async Task<ActionResult> DeleteUser([FromQuery] Guid isnNode)
        {
            _userManager.Delete(isnNode);
            return Ok();
        }
        [HttpGet(nameof(GetListUser), Name = nameof(GetListUser))]
        public async Task<ActionResult> GetListUser()
        {
            var user = _userManager.GetListUser(new UserFilterDto());
            return Ok(user);
        }
    }
}
