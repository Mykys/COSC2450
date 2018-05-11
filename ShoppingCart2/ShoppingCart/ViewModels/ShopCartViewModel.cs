using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCart.Models;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.ViewModels
{
    public class ShopCartViewModel
    {
        [Key]
        public int ShopCartViewID { get; set; }
        public List<Cart> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
}