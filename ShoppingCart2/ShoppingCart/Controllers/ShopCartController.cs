using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    public class ShopCartController : Controller
    {
        ShoppingCartContext storeDB = new ShoppingCartContext();

        // GET: ShopCart
        public ActionResult Index()
        {
            var cart = ShopCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShopCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

        //// GET: /Store/AddToCart/5
        //public ActionResult AddToCart(int id, FormCollection values)
        //{
        //    // Retrieve the album from the database
        //    var addedProduct = storeDB.Products
        //        .Single(product => product.ProductID == id);

        //    // Add it to the shopping cart
        //    var cart = ShopCart.GetCart(this.HttpContext);

        //    // Go back to the main store page for more shopping
        //    cart.AddToCart(addedProduct);
        //    return RedirectToAction("Index");
            
        //}

        // POST: /Store/AddToCart/5
        [HttpPost]
        public ActionResult AddToCart(int id, FormCollection values)
        {
            // Retrieve the album from the database
            var addedProduct = storeDB.Products
                .Single(product => product.ProductID == id);

            // Add it to the shopping cart
            var cart = ShopCart.GetCart(this.HttpContext);

            int quantity = Int32.Parse(values["Quantity"]);
            for (int i = 0; i < quantity; i++)
            {
                cart.AddToCart(addedProduct);
            }

            return RedirectToAction("Index");            
        }

        // AJAX: /ShopCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShopCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string productName = storeDB.Carts.Include("Product")
                .Single(item => item.RecordID == id).Product.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShopCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteID = id
            };
            return Json(results);
        }

        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShopCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }

    }

}