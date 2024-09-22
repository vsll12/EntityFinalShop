using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFinalShopUser.Models
{
    internal class BasketElement
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string productName { get; set; }
        public int Quantity { get; set; }
        public List<User> Users { get; set; }
    }
}
