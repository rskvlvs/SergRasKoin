using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRasKoin.Features.DtoModels.Sales;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Controllers
{
    [Route(Manage)]
    public class ManageController : Controller
    {
        public const string Manage = "Manage";

        private readonly ISalesManager _salesManager;

        private readonly IUserManager _userManager;

        private Guid _usId;
        public ManageController(ISalesManager salesManager, IUserManager userManager)
        {
            _salesManager = salesManager;
            _userManager = userManager;
        }
        
        //Для адекватного вывода страницы. Сохраняю айди пользователя, закидывая значения в модельку
        [HttpGet(nameof(Sales), Name = nameof(Sales))]
        public async Task<ActionResult> Sales(Guid usId) //Попытка сохранить пользовательский айди
        {
            //Попытка сохранить пользовательский айди
            var editSales = new EditSales { UserId = usId };
            return View(editSales);
        }

        //Вывожу сумму пользователя. Сделал, чтобы выводилась страница в отдельном методе
        [HttpGet(nameof(GetSumSales), Name = nameof(GetSumSales))]
        public async Task<ActionResult> GetSumSales(SalesDto salesDto)
        {
            return View(salesDto);
        }

        
        //[HttpGet(nameof(CreateSales))]
        //public IActionResult CreateSales(Guid userId)
        //{
        //    return View(new EditSales { UserId = userId }); 
        //}

        //Мне не нужно обновление продаж, так как каждая покупка пользователя идет в отдельную строчку
        //[HttpPut(nameof(UpdateSales), Name = nameof(UpdateSales))]
        //public async Task<ActionResult> UpdateSales(EditSales sales)
        //{
        //    _salesManager.Update(sales);
        //    return Ok(); 
        //}

        //Здесь метод для покупки пользователем коинов. Создаю продажу, перехожу на юзер меню.
		[HttpPost(nameof(CreateSalesViewAsync), Name = nameof(CreateSalesViewAsync))]
		public async Task<ActionResult> CreateSalesViewAsync(EditSales sales)
		{
			if (!ModelState.IsValid)
				return View(nameof(Sales), sales);

			_salesManager.Create(sales);
            var user = _userManager.GetUser(sales.UserId);
            return RedirectToAction(nameof(UserMenuController.Menu), UserMenuController.UserMenu, new { usId = sales.UserId, name = user.Name, surname = user.Surname });
            //return RedirectToAction(nameof(GetListSales));
        }

        //Возвращает лист продаж
		[HttpGet(nameof(GetListSales), Name = nameof(GetListSales))]
		public async Task<ActionResult> GetListSales()
		{
			var sales = _salesManager.GetListSales(new SalesFilterDto());
			return Ok(sales);
		}

        //Эта функция для страницы с балансом пользователя.
        [HttpGet(nameof(GetSumSalesAsync), Name = nameof(GetSumSalesAsync))]
        public async Task<ActionResult> GetSumSalesAsync(Guid usId)
        {
            try
            {
                var salesDto = _salesManager.GetSumById(usId);
                return View(nameof(GetSumSales), salesDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(UserMenuController.Menu), usId);
            }
        }

        [HttpGet(nameof(SaleUserCoinsView), Name = nameof(SaleUserCoinsView))]
        public async Task<ActionResult> SaleUserCoinsView(Guid usId)
        {
            return View(new EditSales() { UserId = usId });
        }

        [HttpPost(nameof(SaleUserCoinsAsync), Name = nameof(SaleUserCoinsAsync))]
        public async Task<ActionResult> SaleUserCoinsAsync(EditSales sales)
        {
            if (!ModelState.IsValid)
                return View(nameof(Sales), sales);

            var sumSalesDto = _salesManager.GetSumById(sales.UserId); 
            if(sumSalesDto.SumOfCoint< sales.Count_Of_Coins)
            {
                ModelState.AddModelError(string.Empty, "Вы не можете продать больше, чем у вас есть");
                return View(nameof(SaleUserCoinsView), sales);
            }

            _salesManager.Create(new EditSales() { IsnNode = sales.IsnNode, Count_Of_Coins = sales.Count_Of_Coins * (-1), UserId = sales.UserId});
            var user = _userManager.GetUser(sales.UserId);
            return RedirectToAction(nameof(UserMenuController.Menu), UserMenuController.UserMenu, new { usId = sales.UserId, name = user.Name, surname = user.Surname });
        }
    }
}
