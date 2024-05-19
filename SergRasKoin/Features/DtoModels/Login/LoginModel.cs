using SergRasKoin.Features.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.Login
{
    public sealed record LoginModel
    {
        [Required]
        public string? email { get; init; }
    }
}
