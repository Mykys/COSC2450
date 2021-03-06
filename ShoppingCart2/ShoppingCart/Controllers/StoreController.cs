﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class StoreController : Controller
    {
        ShoppingCartContext storeDB = new ShoppingCartContext();

        // GET: Store
        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();

            return View(categories);
        }

        // GET: /Store/Browse?category=Shoes
        public ActionResult Browse(string category)
        {
            var categoryModel = storeDB.Categories.Include("Products")
               .Single(c => c.Title == category);

            return View(categoryModel);
        }

        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);

            return View(product);
        }

        // GET: /Store/CategoryeMenu
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();
            return PartialView(categories);
        }

        // GET: /Store/Details
        //public ActionResult Details(FormCollection value)
        //{
        //    string val = value["PromoCode"].ToString();
        //    return View(val);
        //}
    }
}