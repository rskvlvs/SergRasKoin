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
            var user = _userManager.GetListUser(new UserFilterDto()).FirstOrDefault();
            return View(user);
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

            _userManager.Create(user);
            //return RedirectToAction(nameof(GetListUser));
            //var usId = user.IsnNode; 
            return RedirectToAction("Sales", "Manage");
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
