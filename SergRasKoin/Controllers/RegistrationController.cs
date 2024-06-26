﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SergRasKoin.Features.DtoModels.Sales;
using SergRasKoin.Features.Interfaces.Managers;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRasKoin.Features.DtoModels.User;
using SergRasKoin.Features.Managers;

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

        //Открытие View
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

        //Мне не нужно обновление пользователя
        //[HttpPut(nameof(UpdateUser), Name = nameof(UpdateUser))]
        //public async Task<ActionResult> UpdateUser(EditUser user)
        //{
        //    _userManager.Update(user);
        //    return Ok();
        //}

        //Создаю нового пользователя
        [HttpPost(nameof(CreateUserView), Name = nameof(CreateUserView))]
        public async Task<ActionResult> CreateUserView(EditUser user)
        {
            if (!ModelState.IsValid)
                return View(nameof(User), user);
            var temp = await _userManager.GetUserByMail(user.Email);
            if (temp != null)
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже существует");
                return View(nameof(User), user);
            }
            try
            {
                var usId = _userManager.Create(user);
                return RedirectToAction(nameof(UserMenuController.Menu), UserMenuController.UserMenu, new { usId = usId, name = user.Name, surname = user.Surname });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(CreateUserView), user);
            }
        }

        //Для будущего удаления данных о пользователе
        [HttpPut(nameof(DeleteUser), Name = nameof(DeleteUser))]
        public async Task<ActionResult> DeleteUser([FromQuery] Guid isnNode)
        {
            _userManager.Delete(isnNode);
            return Ok();
        }

        //Возвращает список пользователей
        [HttpGet(nameof(GetListUser), Name = nameof(GetListUser))]
        public async Task<ActionResult> GetListUser()
        {
            var user = _userManager.GetListUser(new UserFilterDto());
            return Ok(user);
        }
    }
}
