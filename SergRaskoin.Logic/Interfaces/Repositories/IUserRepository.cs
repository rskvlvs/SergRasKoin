using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRaskoin.Logic.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(DataContext context, User user);

        public User Update(DataContext context, User user);

        void Delete(DataContext context, Guid isnNode);

        User GetById(DataContext context, Guid isnNode);

        Task<User> GetByMail(DataContext context, string mail);

    }
}
