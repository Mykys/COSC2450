using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}