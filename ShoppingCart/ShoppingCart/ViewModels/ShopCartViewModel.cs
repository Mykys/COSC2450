using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCart.Models;

namespace ShoppingCart.ViewModels
{
    public class ShopCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
}