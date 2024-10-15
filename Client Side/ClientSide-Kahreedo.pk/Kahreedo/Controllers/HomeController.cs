using Khareedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Khareedo.Controllers
{
    public class HomeController : Controller
    {
        KhareedoEntities db = new KhareedoEntities();

        // GET: Home
        public ActionResult Index()
        {
         
            ViewBag.WomenProduct = db.Products.Where(x => x.Category.Name.Equals("Gaming PC")).ToList();
            ViewBag.MenProduct = db.Products.Where(x => x.Category.Name.Equals("Laptop")).ToList();
            ViewBag.SportsProduct = db.Products.Where(x => x.Category.Name.Equals("Motherboards")).ToList();
            ViewBag.ElectronicsProduct = db.Products.Where(x => x.Category.Name.Equals("Graphic Cards")).ToList();
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();

            this.GetDefaultData();

            return View();
        }      

    }
}