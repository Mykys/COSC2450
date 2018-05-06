using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNbr { get; set; }
        public string Email { get; set; }
        public double Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}