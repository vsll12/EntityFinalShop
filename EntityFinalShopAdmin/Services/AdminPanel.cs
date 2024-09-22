using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFinalShopAdmin.Services
{
    internal static class AdminPanel
    {
        public static void LogIn()
        {
            if (AdminManager.Admin is null)
            {

            LogIn:
                Console.Clear();
                Console.Write("Enter the email : ");
                string email = Console.ReadLine()!;
                Console.Write("Enter the password : ");
                string password = Console.ReadLine()!;
                try
                {
                    AdminManager.Login(email, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                    goto LogIn;
                }

            }

            else
            {
                Console.WriteLine("Welcome");
                Thread.Sleep(2000);
            }

        }

        public static void LogOut()
        {
            AdminManager.LogOut();
        }

        public static void MainMenu()
        {
            bool condition = true;

            while (condition)
            {

            MainMenu:

                Console.Clear();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add category");
                Console.WriteLine("2. Add product");
                Console.WriteLine("3. Update the product");
                Console.WriteLine("4. LogOut");
                Console.WriteLine("5. Reports");
                Console.WriteLine("6. Statistics");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":

                        condition = false;
                        break;

                    case "1":
                        
                        Console.Write("Enter the name : ");
                        var name = Console.ReadLine()!;

                        AdminManager.AddCategory(name);

                        Console.WriteLine("Category added");
                        Thread.Sleep(2000);

                        break;

                    case "2":

                        Console.Write("Enter the name : ");
                        var p_name = Console.ReadLine()!;
                        Console.Write("Enter the description : ");
                        var desc = Console.ReadLine()!;
                        Console.Write("Enter the price : ");
                        decimal price = decimal.Parse(Console.ReadLine()!);
                        Console.Write("Enter the quantity : ");
                        int quant = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter the categoryId :");
                        int categoryId = int.Parse(Console.ReadLine()!);

                        AdminManager.AddProduct(p_name, desc, quant, categoryId, price);

                        Console.WriteLine("Product added");
                        Thread.Sleep(2000);

                        break;

                    case "3":

                        Console.Write("Enter the name : ");
                        var name_u = Console.ReadLine()!;
                        Console.Write("Enter the new categoryId : ");
                        int category_u = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter the new description : ");
                        var desc_u = Console.ReadLine()!;
                        Console.Write("Enter the new price : ");
                        decimal price_u = decimal.Parse(Console.ReadLine()!);

                        AdminManager.UpdateTheProduct(name_u, desc_u, price_u, category_u);
                        Console.WriteLine("Product updated");
                        Thread.Sleep(2000);

                        break;

                    case "4":

                        AdminManager.LogOut();
                        condition = false;

                        break;

                    case "5":

                        //Reports
                        AdminManager.ShowReports();
                        Console.ReadKey();

                        break;

                    case "6":
                        //Statistics
                        break;
                    default:

                        Console.WriteLine("Wrong choice");
                        Thread.Sleep(2000);

                        goto MainMenu;
                }
            }

        }
    }
}
