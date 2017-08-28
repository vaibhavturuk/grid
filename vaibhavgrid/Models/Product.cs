using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vaibhavgrid.Models
{
    public class Product
    {
        public Product()
        {
            List<Order> orderList = new List<Order>();
        }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}