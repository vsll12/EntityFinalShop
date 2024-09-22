using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFinalShopUser.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public List<BasketElement> BasketElements { get; set; }
        public List<HistoryItem> History { get; set; }

        public void ShowInfo()
        {
            Console.Write($"{Name}  {Description}  {Category}  {Price}  {Quantity}");
        }

    }
}
