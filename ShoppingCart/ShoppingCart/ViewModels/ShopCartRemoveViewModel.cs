using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.ViewModels
{
    public class ShopCartRemoveViewModel
    {
        public string Message { get; set; }
        public double CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteID { get; set; }
    }
}