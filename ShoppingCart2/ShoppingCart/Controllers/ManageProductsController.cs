using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageProductsController : Controller
    {
        // GET: ManageProducts
        public ActionResult Index()
        {
            return View();
        }
    }
}