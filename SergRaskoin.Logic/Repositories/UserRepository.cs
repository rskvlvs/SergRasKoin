using Microsoft.EntityFrameworkCore;
using SergRaskoin.Logic.Interfaces.Repositories;
using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(DataContext context, User user)
        {
            //user.IsnNode = Guid.NewGuid();
            context.Users.Add(user);
            return user;
        }

        public User Update(DataContext context, User user)
        {
            var userDb = context.Users.FirstOrDefault(x => x.IsnNode == user.IsnNode)
                ?? throw new Exception($"Пользователь с идентификатором {user.IsnNode} не найдена");

            userDb.Name = user.Name;
            userDb.Surname = user.Surname;
            userDb.Email = user.Email;

            return userDb;
        }

        public void Delete(DataContext context, Guid isnNode)
        {
            var userDb = context.Users.FirstOrDefault(x => x.IsnNode == isnNode)
               ?? throw new Exception($"Пользователь с идентификатором {isnNode} не найден");

            context.Users.Remove(userDb);

        }

        public User GetById(DataContext context, Guid isnNode)
        {
            var userDb = context.Users.AsNoTracking().FirstOrDefault(x => x.IsnNode == isnNode)
                ?? throw new Exception($"Пользователь с идентификатором {isnNode} не найден");

            return userDb;
        }

        public async Task<User> GetByMail(DataContext context, string mail)
        {
            var userDb = await context.Users.AsNoTracking().Include(m => m.Sale).FirstOrDefaultAsync(x => x.Email == mail)
                ?? throw new Exception($"Пользователь с email {mail} не найден");
            return userDb;
        }


    }
}
