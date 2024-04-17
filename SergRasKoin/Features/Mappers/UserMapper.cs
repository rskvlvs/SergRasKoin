using AutoMapper;
using SergRasKoin.Features.DtoModels.User;
using SergRasKoin.Storage.Models;

namespace SergRasKoin.Features.Mappers
{
	public class UserMapper : Profile
	{
		public UserMapper()
		{
			CreateMap<User, EditUser>();
			CreateMap<EditUser, User>();
		}
	}
}
