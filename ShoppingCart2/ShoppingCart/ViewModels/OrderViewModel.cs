using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCart.Models;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public int OrderID { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Product> ProductList { get; set; }
        public double CartTotal { get; set; }
    }
}