using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SergRasKoin.Features.DtoModels.User
{
	public class UserDto
	{
        public Guid IsnNode { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
    }
}
