using EntityFinalShopUser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFinalShopUser.Helpers
{
    internal static class ProfileManager
    {
        public static void ChangeName()
        {
            Console.Clear();

            Console.Write("Enter your new name : ");

            var NewName = Console.ReadLine();

            UserManager.User.Name = NewName;

            UserManager.context.Users.Update(UserManager.User);
            UserManager.context.SaveChanges();  
        }

        public static void ChangePassword()
        {
        Change:
            Console.Clear();
            Console.Write("Enter your old password : ");

            var OldPassword = Console.ReadLine();

            if (UserManager.User!.Password == OldPassword)
            {
                Console.Write("Enter your new password : ");
                var newPass = Console.ReadLine();
                UserManager.User.Password = newPass;
                UserManager.context.Users.Update(UserManager.User);
                UserManager.context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Old password is wrong");
                Thread.Sleep(2000);
                Console.Clear();
                goto Change;
            }
        }

        public static void History()
        {
            UserManager.ShowBasket();
        }

        public static void LogOut()
        {
            UserManager.LogOut();
        }

    }
}
