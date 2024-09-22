using EntityFinalShopUser.Helpers;
using EntityFinalShopUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFinalShopUser.Services
{
    internal static class UserPanel
    {
        public static void MainPage()
        {

            Console.Clear();
            Console.WriteLine("0 .Exit");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. LogIn");
        }

        public static void RegisterPage()
        {
        Register:

            Console.Clear();
            Console.Write("Name : ");
            var name = Console.ReadLine();

            Console.Write("Surname : ");
            var surname = Console.ReadLine();

            Console.Write("DateOfBirth (dd.MM.yyyy):");
            var date = Console.ReadLine();

            Console.Write("Email : ");
            var email = Console.ReadLine();

            Console.Write("Password : ");
            var password = Console.ReadLine();

            try
            {
                UserManager.Register(name!, surname!, email!.ToLower().Trim(), password!, date!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
                goto Register;
            }
        }


        public static void LogInPage()
        {
        LogIn:

            Console.Clear();

            Console.Write("Email :");
            var email = Console.ReadLine();

            Console.Write("Password : ");
            var password = Console.ReadLine();

            try
            {
                UserManager.LogIn(email!, password!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
                goto LogIn;
            }
        }


        public static void UserMenu()
        {
            bool condition = true;
            Console.Clear();
            while (condition)
            {

                if (UserManager.User is not null)
                {
                UserMenu:

                    Console.Clear();
                    Console.WriteLine($"1. Categories");
                    Console.WriteLine($"2. Basket");
                    Console.WriteLine($"3. Profile");
                    Console.WriteLine($"4. Exit");

                    Console.Write("Enter your choice : ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                        categories:

                            var categories = UserManager.context.Categories.ToList();
                            var products = UserManager.context.Products.ToList();

                            Console.WriteLine("0. Back");

                            for (int i = 0; i < categories.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {categories[i].Name}");
                            }
                            Console.Write("Enter your choice : ");
                            int ch = int.Parse(Console.ReadLine()!);

                            if (ch == 0) { goto UserMenu; }

                        Products:

                            var productsInThisCategory = UserManager.context.Products.Where(p => p.Category == categories[ch - 1]).ToList();

                            Console.WriteLine("0.Back");
                            for (int i = 0; i < productsInThisCategory.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{productsInThisCategory[i].Name}");
                            }

                            Console.Write("Enter your choice : ");

                            int choiceForProdInfo = int.Parse(Console.ReadLine()!);

                            if (choiceForProdInfo == 0) { goto categories; }

                            var productForInfo = UserManager.context.Products.FirstOrDefault(p => p == productsInThisCategory[choiceForProdInfo - 1]);

                            if (productForInfo is not null)
                            {
                                Console.WriteLine($"{productForInfo.Id}  {productForInfo.Name}");
                            }

                            Console.WriteLine("0. Back");
                            Console.WriteLine("1. Add to basket");
                            Console.Write("Enter your choice : ");

                            int choiceForBuyOrBack = int.Parse(Console.ReadLine()!);

                            if (choiceForBuyOrBack == 0) { goto Products; }

                            else if (choiceForBuyOrBack == 1)
                            {
                            quantity:

                                Console.Clear();
                                Console.Write("Enter the quantity of product : ");
                                int quant = int.Parse(Console.ReadLine()!);

                                try
                                {
                                    UserManager.AddProductToBasket(productForInfo.Name, quant, productForInfo.Price);

                                    HistoryItem historyItem = new HistoryItem()
                                    {
                                        Date = DateTime.Now,
                                        Product = productForInfo,
                                        User = UserManager.User
                                    };

                                    UserManager.User.History.Add(historyItem);
                                    UserManager.context.Update(UserManager.User);
                                    UserManager.context.SaveChanges();

                                    if (productForInfo.Quantity - quant >= 0)
                                    {
                                        productForInfo.Quantity -= quant;
                                        UserManager.context.Products.Update(productForInfo);
                                        UserManager.context.SaveChanges();
                                    }
                                    else
                                    {
                                        Console.WriteLine("That much product doesn't exist");
                                        Thread.Sleep(2000);
                                        goto quantity;
                                    }
                                    goto Products;
                                }
                                catch (Exception ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(2000);
                                    goto Products;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong choice");
                                Thread.Sleep(2000);
                                Console.Clear();
                                goto Products;
                            }

                        case "2":
                            //Basket
                            Console.Clear();
                            Console.WriteLine("0. Back to the UserMenu");
                            Console.WriteLine("1. Buy");
                            Console.WriteLine("2. Remove the element");

                            UserManager.ShowBasket();

                            Console.Write("Enter your choice : ");
                            var choice_p = int.Parse(Console.ReadLine()!);

                            if (choice_p == 0)
                            {
                                goto UserMenu;
                            }
                            else if (choice_p == 1)
                            {
                            Amount:
                                Console.Clear();
                                Console.WriteLine($"Total amount : {UserManager.Total}");
                                Console.Write("Enter the amount : ");
                                var amount = double.Parse(Console.ReadLine()!);
                                if (amount == UserManager.Total)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Thanks");
                                    Thread.Sleep(2000);
                                    return;
                                }
                                else if (amount > UserManager.Total)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Qaliq : {amount - UserManager.Total}");
                                    Thread.Sleep(2000);
                                }
                                else if (amount < UserManager.Total)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Wrong amount");
                                    Thread.Sleep(2000);

                                    goto Amount;
                                }

                            }
                            else if (choice_p == 2)
                            {
                                UserManager.ShowBasket();

                                Console.Write("Enter product name : ");
                                string name = Console.ReadLine();

                                UserManager.RemoveTheProductFromBasket(name);
                            }
                            break;
                        case "3":
                            //Profile
                            Console.WriteLine("1. Change name ");
                            Console.WriteLine("2. Change password ");
                            Console.WriteLine("3. History ");
                            Console.WriteLine("4. Log out ");

                            Console.Write("Enter your choice : ");

                            var prof_choice = int.Parse(Console.ReadLine()!);

                            if (prof_choice == 1)
                            {
                                ProfileManager.ChangeName();
                            }
                            else if (prof_choice == 2)
                            {
                                ProfileManager.ChangePassword();
                            }
                            else if (prof_choice == 3)
                            {
                                ProfileManager.History();
                            }
                            else if (prof_choice == 4)
                            {
                                ProfileManager.LogOut();
                            }
                            break;
                        case "4":
                            //Exit
                            condition = false;
                            //return;
                            Console.Clear();
                            Console.WriteLine("...");
                            Thread.Sleep(2000);
                            break;
                        default:

                            Console.WriteLine("Wrong choice");
                            Thread.Sleep(2000);
                            Console.Clear();

                            goto UserMenu;
                            //break
                    }
                }
            }
        }
    }
}
