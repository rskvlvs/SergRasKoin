using SergRasKoin.Storage.DataBase;
using SergRasKoin.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergRasKoin.Storage.Extensions.Models
{
    public static class UserExtensions
    {
        public static string GetUserInfo(this User user, DataContext context)
        {
            // Получаем Count_Of_Coins для данного пользователя
            var countOfCoins = context.Sale.Where(s => s.UserId == user.IsnNode).Sum(s => s.Count_Of_Coins);

            return string.Join(" ", (new string[]
            {
                user.Name,
                user.Surname,
                user.Email,
                "Count of Coins = " + countOfCoins.ToString()
            }).Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
