using SergRasKoin.Storage.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.Sales
{
    public sealed record SalesDto
    {
        public Guid IsnNode { get; init; }

        public Guid UserId { get; init; }

        public long Count_Of_Coins { get; init; }
        
        public long SumOfCoint { get; set; }
    }
}
