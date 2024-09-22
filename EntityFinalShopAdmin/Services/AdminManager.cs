using EntityFinalShopAdmin.Data;
using EntityFinalShopAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EntityFinalShopAdmin.Services
{
    internal static class AdminManager
    {
        public static ShopDbContext context = new ShopDbContext();
        public static List<Admin> Admins { get; set; } = [];
        public static List<Category> Categories { get; set; } = [];
        public static List<Product> Products { get; set; } = [];
        public static List<ReportElement> Reports { get; set; } = [];
        public static Admin? Admin { get; set; }

        static AdminManager() 
        {
            Admins = context.Admins.ToList();
            Categories = context.Categories.ToList();
            Products = context.Products.ToList();
            Reports = context.ReportElements.ToList();
        }

        public static void Login(string email, string password)
        {
            Admin = context.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);
            if (Admin == null) throw new Exception("Invalid email or password");
        }

        public static void LogOut()
        {
            Admin = null;
        }

        public static void AddCategory(string name)
        {
            var category1 = context.Categories.FirstOrDefault(c => c.Name == name);
            if (category1 is not null) throw new Exception("This category is already exist");
            Category category =new Category() { Name = name };
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public static void AddProduct(string name, string description, int quantity, int categoryId, decimal price)
        {
            Product product = new Product() { Name = name, Description = description, Quantity = quantity, CategoryId = categoryId, Price = price };
            var product1 = context.Products.FirstOrDefault(p => p.Name == name);
            if(product1 is not null)
            {
                throw new Exception("this products is already exist");
            }
            else
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static void UpdateTheProduct(string name, string newDescription, decimal newPrice, int newCategoryId)
        {
            var product = context.Products.FirstOrDefault(p => p.Name == name);
            if (product is null) throw new Exception("Product not found");
            product.Description = newDescription;
            product.Price = newPrice;
            product.CategoryId = newCategoryId;
            context.Products.Update(product);
            context.SaveChanges();
        }

        public static void ShowReports()
        {
            Console.Clear();
            Reports = context.ReportElements.ToList();
            foreach (ReportElement reportElement in Reports)
            {
                Console.WriteLine($"{reportElement.Id}  {reportElement.Date}  {reportElement.ProductQuantity}");
            }
        }




    }
}
