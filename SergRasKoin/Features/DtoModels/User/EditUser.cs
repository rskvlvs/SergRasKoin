using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.User
{
	public class EditUser
	{
		public Guid? IsnNode { get; init; }

		[Required]
		public string Name { get; init; }

		[Required]
		public string Surname { get; init; }

		[Required]
		public string Email { get; init; }
	}
}
