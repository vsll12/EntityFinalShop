using Bogus;
using EntityFinalShopUser.Data;
using EntityFinalShopUser.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EntityFinalShopUser.Services
{
    internal static class UserManager
    {

        public static Faker<User> faker = new Faker<User>();
        public static double Total { get; set; }
        public static User? User { get; set; }

        public static ShopUserDbContext context = new ShopUserDbContext();
        static UserManager()
        { 
         
        }

        public static void Register(string name, string surname, string email, string password, string date)
        {
          var user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user is null) 
            {
                user = new User()
                {
                    Email = email,
                    Password = password,
                    DateOfBirth = DateTime.Parse(date),
                    Name = name,
                    Surname = surname
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("This user is already exist!");
            }
        }

        public static void LogIn(string email, string password)
        {
            User = context.Users.FirstOrDefault(u => u.Email == email.ToLower().Trim() && u.Password == password);
            if (User is null) throw new Exception("Invalid email or password");
        }

        public static void LogOut()
        {
            User = null;
        }

        public static void AddProductToBasket(string name,int quantity,double price)
        {
            if (User is not null)
            {
                var be = new BasketElement()
                {
                    productName = name,
                    Quantity = quantity,
                    Price = price
                };
                User.Basket.Add(be);
                context.Users.Update(User);
                context.SaveChanges();
                Total += price;
                return;
            }
            throw new Exception("User is not found");
        }

        public static void ShowBasket()
        {

           
            int i = 0;
            foreach (var BasketElement in User.Basket)
            { 

                Console.WriteLine($"{i + 1}. {BasketElement.productName}  {BasketElement.Quantity}");
                i++;
            }
            return;
           
        }

        public static void RemoveTheProductFromBasket(string name)
        {

            var prod = User.Basket.FirstOrDefault(p => p.productName == name);
            if (prod is not null) 
            {
                User.Basket.Remove(prod);
                context.Users.Update(User);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("This element doesn't exist!");
            }
        }
    }
}
