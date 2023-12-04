using OOPTryouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.ConsoleApp
{
    static class MyExtensions
    {
        public static void UserInfo(this User<ShopGoods> user)
        {
            Console.WriteLine($"Инфа о пользователе.\nИмя:{user.Name}, номер телефона: {user.PhoneNumber},почта: {user.Email}"); 
        }   
    }
}
