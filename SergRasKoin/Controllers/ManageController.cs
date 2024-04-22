using Microsoft.AspNetCore.Mvc;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRasKoin.Features.DtoModels.Sales;
using SergRasKoin.Features.Interfaces.Managers;

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
            //Разобраться с этой передачей Dto во Views
            //var sales = _salesManager.GetListSales(new SalesFilterDto()).FirstOrDefault(); 
            //return View(sales);
            return View(editSales);
        }

        [HttpGet(nameof(CreateSales))]
        public IActionResult CreateSales(Guid userId)
        {
            return View(new EditSales { UserId = userId }); 
        }

        [HttpPut(nameof(UpdateSales), Name = nameof(UpdateSales))]
        public async Task<ActionResult> UpdateSales([FromBody]EditSales sales)
        {
            _salesManager.Update(sales);
            return Ok(); 
        }

		[HttpPost(nameof(CreateSalesView), Name = nameof(CreateSalesView))]
		public async Task<ActionResult> CreateSalesView(EditSales sales) //Вторая попытка сохранить айдишник
		{
			if (!ModelState.IsValid)
				return View(nameof(Sales), sales);

			_salesManager.Create(sales);
			return RedirectToAction(nameof(GetListSales));
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
	}
}
