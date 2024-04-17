using SergRasKoin.Storage.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.Sales
{
    public sealed record SalesDto
    {
        [Key]
        public Guid IsnNode { get; init; }


        [ForeignKey(nameof(User))]
        public Guid UserId { get; init; }

        public long Count_Of_Coins { get; init; }

    }
}
