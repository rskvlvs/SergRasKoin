using SergRaskoin.Logic.DtoModels.Filters;
using SergRasKoin.Features.DtoModels.Sales;

namespace SergRasKoin.Features.Interfaces.Managers
{
    public interface ISalesManager
    {
		void Create(EditSales editSales);

		//void Update(EditSales updateSales);

		void Delete(Guid isnNode);

		SalesDto GetSales(Guid isnNode);

		SalesDto[] GetListSales(SalesFilterDto filter);

		SalesDto GetSumById(Guid? usId);

    }
}
