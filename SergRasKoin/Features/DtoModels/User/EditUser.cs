using SergRasKoin.Features.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.User
{
	public class EditUser
	{
		public Guid? IsnNode { get; init; }

        //[Required, NoDigit]
        [Required, OnlyLetter]
        public string Name { get; init; }

        //[Required, NoDigit]
        [Required, OnlyLetter]
        public string Surname { get; init; }

		[Required, CorrectEmail]
		public string Email { get; init; }
	}
}
