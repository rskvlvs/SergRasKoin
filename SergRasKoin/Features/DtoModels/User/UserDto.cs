using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.User
{
	public class UserDto
	{
		[Key]
		public Guid IsnNode { get; init; }

		[Required, MaxLength(255)]
		public string Name { get; init; }

		[Required, MaxLength(255)]
		public string Surname { get; init; }

		[Required, MaxLength(255)]
		public string Email { get; init; }
	}
}
