using Microsoft.AspNetCore.Mvc;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRasKoin.Features.DtoModels.Sales;
using SergRasKoin.Features.Interfaces.Managers;

namespace SergRasKoin.Controllers
{
    [Route("Manage")]
    public class ManageController : Controller 
    {
        private readonly ISalesManager _salesManager;
        public ManageController(ISalesManager salesManager) 
        { 
            _salesManager = salesManager;
        }

        [HttpGet(nameof(Sales), Name = nameof(Sales))]
        public async Task<ActionResult> Sales()
        {
            var sales = _salesManager.GetListSales(new SalesFilterDto()).FirstOrDefault(); 
            return View(sales);
        }

        [HttpPost(nameof(CreateSales), Name = nameof(CreateSales))]
        public async Task<ActionResult> CreateSales([FromBody]EditSales sales)
        {
            _salesManager.Create(sales);
            return Ok(); 
        }

        [HttpPut(nameof(UpdateSales), Name = nameof(UpdateSales))]
        public async Task<ActionResult> UpdateSales([FromBody]EditSales sales)
        {
            _salesManager.Update(sales);
            return Ok(); 
        }
		[HttpPost(nameof(CreateSalesView), Name = nameof(CreateSalesView))]
		public async Task<ActionResult> CreateSalesView([FromBody] EditSales sales)
		{
			if (!ModelState.IsValid)
				return View(nameof(Sales), sales);

			_salesManager.Create(sales);
			return View();
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
