using IMS_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS_Project.Controllers
{
    public class ProductController : Controller
    {
        KahreedoEntities db = new KahreedoEntities();

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Create()
        {
            GetViewBagData();
            return View();
        }

        public void GetViewBagData()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "SubCategoryID", "Name");
        }

        [HttpPost]
        public ActionResult Create(Product prod)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(prod);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Product added successfully!";  // Add success message
                return RedirectToAction("Index", "Product");
            }
            GetViewBagData();
            return View();
        }

        // Get Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Single(x => x.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            GetViewBagData();
            return View("Edit", product);
        }

        // Post Edit
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Product updated successfully!";  // Add success message
                return RedirectToAction("Index", "Product");
            }
            GetViewBagData();
            return View(prod);
        }

        // Get Details
        public ActionResult Details(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // Get Delete
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Product deleted successfully!";  // Add success message
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
