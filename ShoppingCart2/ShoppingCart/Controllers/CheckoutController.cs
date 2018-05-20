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

            cart.CreateOrder(order);
            storeDB.SaveChanges();

            return RedirectToAction("Complete", new { id = order.OrderID });


        }

        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Get ordered items from id
            // Return the View with order
            var order = storeDB.Orders.Include("OrderDetails.Product").Single(item => item.OrderID == id);

            // Set up our ViewModel
            var viewModel = new OrderViewModel
            {
                OrderID = order.OrderID,
                OrderDetails = order.OrderDetails,
                CartTotal = order.Total
            };

            return View(viewModel);
        }


    }
}