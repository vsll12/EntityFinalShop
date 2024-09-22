using EntityFinalShopAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFinalShopAdmin.Data
{
    internal class ShopDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7F74UDB;Initial Catalog=ShopDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<ReportElement> ReportElements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Admin>()
            //            .HasData(new Admin() 
            //            { 
            //              Id = 1,
            //              Name = "admin", 
            //              Password = "admin", 
            //              Surname = "admin", 
            //              Email = "admin@mail.com" 
            //            }
            //);

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().Property(p => p.Id).UseIdentityColumn();

            //modelBuilder.Entity<Category>().HasData(new Category() { Id = -1, Name = "c1" },
            //    new Category() { Id = -2, Name = "c2" },
            //    new Category() { Id = -3, Name = "c3" });

            //modelBuilder.Entity<Product>().HasData(new Product() { Id = -1, Name = "p1", Description = "d1", Price = 10, Quantity = 100, CategoryId = 1 },
            //    new Product() { Id = 2, Name = "p2", Description = "d2", Price = 20, Quantity = 130, CategoryId = 2 },
            //    new Product() { Id = 3, Name = "p3", Description = "d3", Price = 15, Quantity = 110, CategoryId = 3 });

            //var categories = new List<Category>()
            //{
            //    new Category(){ Name = "c1"},
            //    new Category(){ Name = "c2"},
            //    new Category(){ Name = "c3"}
            //};

            //var products = new List<Product>() 
            //{
            //    new Product(){Name = "p1",Description = "d1",Price = 10,Quantity = 100,CategoryId = 1},
            //    new Product(){Name = "p2",Description = "d2",Price = 20,Quantity = 130,CategoryId = 3},
            //    new Product(){Name = "p3",Description = "d3",Price = 15,Quantity = 110,CategoryId = 2}
            //};
        }
    }
}
