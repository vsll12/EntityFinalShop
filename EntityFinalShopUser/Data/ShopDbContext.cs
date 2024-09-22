using EntityFinalShopUser.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFinalShopUser.Data
{
    internal class ShopUserDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7F74UDB;Initial Catalog=ShopUserDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<User> Users {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HistoryItem> HistoryItems { get; set; }
        public DbSet<BasketElement> BasketElements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //modelBuilder.Entity<User>().HasMany(u => u.BasketElements).WithMany(be => be.Users);
        }
    }
}
