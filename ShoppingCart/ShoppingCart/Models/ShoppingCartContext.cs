using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class ShoppingCartContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ShoppingCartContext() : base("name=ShoppingCartContext")
        {
        }

        public System.Data.Entity.DbSet<ShoppingCart.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ShoppingCart.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ShoppingCart.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<ShoppingCart.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<ShoppingCart.Models.OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<ShoppingCart.ViewModels.ShopCartViewModel> ShopCartViewModels { get; set; }
    }
}
