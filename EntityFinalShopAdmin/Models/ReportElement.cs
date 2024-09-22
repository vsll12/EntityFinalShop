using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFinalShopAdmin.Models
{
    internal class ReportElement
    {
        public  int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Product>? Products { get; set; }
        public int ProductQuantity { get; set; }
    }
}
