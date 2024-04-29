using Microsoft.AspNetCore.Mvc;
using SergRaskoin.Logic.DtoModels.Filters;
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

        private Guid _usId;
        public ManageController(ISalesManager salesManager)
        {
            _salesManager = salesManager;
        }

        [HttpGet(nameof(Sales), Name = nameof(Sales))]
        public async Task<ActionResult> Sales(Guid usId) //Попытка сохранить пользовательский айди
        {
            //Попытка сохранить пользовательский айди
            var editSales = new EditSales { UserId = usId };
            return View(editSales);
        }

        [HttpGet(nameof(GetSumSales), Name = nameof(GetSumSales))]
        public async Task<ActionResult> GetSumSales(SalesDto salesDto)
        {
            return View(salesDto);
        }

        [HttpGet(nameof(CreateSales))]
        public IActionResult CreateSales(Guid userId)
        {
            return View(new EditSales { UserId = userId }); 
        }

        [HttpPut(nameof(UpdateSales), Name = nameof(UpdateSales))]
        public async Task<ActionResult> UpdateSales(EditSales sales)
        {
            _salesManager.Update(sales);
            return Ok(); 
        }

		[HttpPost(nameof(CreateSalesViewAsync), Name = nameof(CreateSalesViewAsync))]
		public async Task<ActionResult> CreateSalesViewAsync(EditSales sales)
		{
			if (!ModelState.IsValid)
				return View(nameof(Sales), sales);

			_salesManager.Create(sales);
            return RedirectToAction(nameof(UserMenuController.Menu), UserMenuController.UserMenu, new { usId = sales.UserId });
            //return RedirectToAction(nameof(GetListSales));
        }
		[HttpPut(nameof(DeleteSales), Name = nameof(DeleteSales))]
        public async Task<ActionResult> DeleteSales([FromQuery]Guid isnNode)
        {
            _salesManager.Delete(isnNode);
            return Ok(); 
        }
		[HttpGet(nameof(GetListSales), Name = nameof(GetListSales))]
		public async Task<ActionResult> GetListSales()
		{
			var sales = _salesManager.GetListSales(new SalesFilterDto());
			return Ok(sales);
		}

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
    }
}
