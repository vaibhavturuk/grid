using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vaibhavgrid.Models
{
    public class OrdersJqGridModel
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}