﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SergRaskoin.Logic.DtoModels.Filters;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRaskoin.Logic.Interfaces.Services;
using SergRasKoin.Features.Interfaces.Managers;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using SergRasKoin.Features.DtoModels.User;

namespace SergRasKoin.Features.Managers
{
	public class UserManager : IUserManager
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUserService _userService;
		private readonly DataContext _dataContext;

		public UserManager(IMapper _mapper, IUserRepository userRepository, IUserService userService, DataContext dataContext)
		{
			_mapper = _mapper;
			_userRepository = userRepository;
			_userService = userService;
			_dataContext = dataContext;
		}

		public void Create(EditUser editUser)
		{
			var user = new User()
			{
				IsnNode = editUser.IsnNode,
				Name = editUser.Name,
				Surname = editUser.Surname,
				Email = editUser.Email,
			};
			_userRepository.Create(_dataContext, user);
			_dataContext.SaveChanges();
		}

		public void Update(EditUser updateUser)
		{
			var user = _mapper.Map<User>(updateUser);
			_userRepository.Update(_dataContext, user);
			_dataContext.SaveChanges();
		}

		public void Delete(Guid isnNode)
		{
			_userRepository.Delete(_dataContext, isnNode);
		}

		public UserDto GetUser(Guid isnNode)
		{
			var user = _userRepository.GetById(_dataContext, isnNode);

			return _mapper.Map<UserDto>(user);
		}

		public UserDto[] GetListSales(UserFilterDto filter)
		{
			var user = _userService.GetUserQueryable(_dataContext, filter, true)
				.Select(x => new UserDto
				{
					IsnNode = x.IsnNode,
					Name = x.Name,
					Surname = x.Surname,
					Email = x.Email,
				})
				.ToArray();
			return user;
		}
	}
}