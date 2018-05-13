using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;

namespace ShoppingCart.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ShoppingCartContext storeDB = new ShoppingCartContext();
        // Add credit card later
        const string PromoCode = "FREE";
    
        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        // POST: /Checkout/ADdressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            order.Username = User.Identity.Name;

            // Save Order
            storeDB.Orders.Add(order);
            storeDB.SaveChanges();
            // Process the order
            var cart = ShopCart.GetCart(this.HttpContext);

            return RedirectToAction("Complete");


        }

        //// POST: /Checkout/AddressAndPayment
        //[HttpPost]
        //public ActionResult AddressAndPayment(FormCollection values)
        //{
        //    var order = new Order();
        //    TryUpdateModel(order);

        //    try
        //    {
        //        if (string.Equals(values["PromoCode"], PromoCode,
        //            StringComparison.OrdinalIgnoreCase) == false)
        //        {
        //            return View(order);
        //        }
        //        else
        //        {
        //            order.Username = User.Identity.Name;

        //            // Save Order
        //            storeDB.Orders.Add(order);
        //            storeDB.SaveChanges();
        //            // Process the order
        //            var cart = ShopCart.GetCart(this.HttpContext);
        //            cart.CreateOrder(order);

        //            return RedirectToAction("Complete");
        //        }
               
        //    }
        //    catch
        //    {
        //        // Invalid - redisplay with errors
        //        return View(order);
        //    }
        //}

        // GET: /Checkout/Complete
        public ActionResult Complete()
        {
            // Get ordered items from id
            // Return the View with order

            var cart = ShopCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShopCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        // GET: /Checkout/Complete
        //public ActionResult Complete(int id)
        //{
        //    // Validate customer owns this order
        //    bool isValid = storeDB.Orders.Any(
        //        o => o.OrderID == id &&
        //        o.Username == User.Identity.Name);

        //    if (isValid)
        //    {
        //        return View(id);
        //    }
        //    else
        //    {
        //        return View("Error");
        //    }
        //}
    }
}