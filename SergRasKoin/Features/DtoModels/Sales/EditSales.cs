using SergRasKoin.Storage.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.Sales
{
    public sealed record EditSales
    {
        public Guid? IsnNode { get; init; }

        public Guid? UserId { get; init; }

        [Required]
        public long Count_Of_Coins { get; init; }
    }
}
