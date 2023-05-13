using MultiShop.Contexts;
using MultiShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiShop.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Search(string t)
        {
            var products = db.Products.Where(p => p.IsApproved);
            if (!string.IsNullOrEmpty(t))
            {
                products = products.Where(p => p.Name.Contains(t) || p.Description.Contains(t));
            }
            return View(products.ToList());
        }
        public PartialViewResult _Slider()
        {
            var product = db.Products.Where(x => x.IsApproved && x.Slider).Take(5).ToList();
            return PartialView(product);
        }
        public PartialViewResult _FeaturedProductList() 
        {
            var product = db.Products.Where(x => x.IsApproved && x.IsFeatured).Take(5).ToList();
            return PartialView(product);
        }
        public ActionResult Index()
        {
           var products = db.Products.Where(x=>x.IsApproved).ToList();
            return View(products);
        }
        public ActionResult Product()
        {
            var products = db.Products.Where(x => x.IsApproved).ToList();
            return View(products);
            
        }
        public ActionResult ProductDetail(int id)
        {
             
            var products = db.Products.ToList();
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            return View(product);
        }
        public ActionResult ProductList(int id) 
        {
            return View(db.Products.Where(x=>x.IsApproved && x.CategoryId==id).ToList());
        }
    }
}