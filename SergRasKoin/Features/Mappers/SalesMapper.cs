using AutoMapper;
using SergRasKoin.Features.DtoModels.Sales;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Features.Mappers
{
    public class SalesMapper : Profile
    {
        public SalesMapper()
        {
            CreateMap<Sales, EditSales>().ReverseMap();
            //CreateMap<EditSales, Sales>();

            CreateMap<SalesDto, Sales>().ReverseMap();
        }
    }
}
