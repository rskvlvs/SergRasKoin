using AutoMapper;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRaskoin.Logic.Interfaces.Services;
using SergRaskoin.Logic.Services;
using SergRasKoin.Features.DtoModels.Sales;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Features.Manager
{
    public class SalesManager : ISalesManager
    {
        private readonly IMapper _mapper;
        private readonly ISalesRepository _salesRepository;
        private readonly ISalesService _salesService; 
        private readonly DataContext _dataContext;

        public SalesManager(IMapper _mapper, ISalesRepository salesRepository, ISalesService salesService, DataContext dataContext)
        {
            _mapper = _mapper;
            _salesRepository = salesRepository;
            _salesService = salesService;
            _dataContext = dataContext;
        }

        public void Create(EditSales editSales)
        {
            var sales = new Sales()
            {
                IsnNode = Guid.NewGuid(),
                UserId = editSales.UserId ?? Guid.NewGuid(),
                //UserId = _usId,
                Count_Of_Coins = editSales.Count_Of_Coins,
            };
            _salesRepository.Create(_dataContext, sales);
            _dataContext.SaveChanges();
        }
        public void Update(EditSales updateSales)
        {
            var sales = _mapper.Map<Sales>(updateSales);
            _salesRepository.Update(_dataContext, sales);
            _dataContext.SaveChanges();

        }
        public void Delete(Guid isnNode)
        {
            _salesRepository.Delete(_dataContext, isnNode);
        }
        public SalesDto GetSales(Guid isnNode)
        {
            var sales = _salesRepository.GetById(_dataContext, isnNode);

            return _mapper.Map<SalesDto>(sales);
        }
        public SalesDto[] GetListSales(SalesFilterDto filter)
        {
            var sales = _salesService.GetSalesQueryable(_dataContext, filter, true)
                .Select(x => new SalesDto
                {
                    IsnNode = x.IsnNode,
                    Count_Of_Coins = x.Count_Of_Coins,
                })
                .ToArray();
            return sales;
        }

    }
}
