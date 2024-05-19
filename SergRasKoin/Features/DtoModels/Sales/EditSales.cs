using SergRasKoin.Storage.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SergRasKoin.Features.Attributes;

namespace SergRasKoin.Features.DtoModels.Sales
{
    public sealed record EditSales
    {
        public Guid? IsnNode { get; init; }

        public Guid? UserId { get; init; }

        //[Required, NoLetter]
        [Required, OnlyDigits]
        public long Count_Of_Coins { get; init; }
    }
}
