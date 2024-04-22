using SergRaskoin.Logic.DtoModels.Filters;
using SergRasKoin.Features.DtoModels.User;

namespace SergRasKoin.Features.Interfaces.Managers
{
	public interface IUserManager
	{
		Guid Create(EditUser editUser);

		void Update(EditUser updateUser);

		void Delete(Guid isnNode);

		UserDto GetUser(Guid isnNode);

		UserDto[] GetListUser(UserFilterDto filter);

	}
}
