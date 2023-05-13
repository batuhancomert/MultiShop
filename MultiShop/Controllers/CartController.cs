using MultiShop.Contexts;
using MultiShop.Entity;
using MultiShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiShop.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private void SaveOrder(Cart cart, ShippingDetail model)
        {
            var order = new Order();
            order.OrderNumber = "S" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.Address = model.Address;
            order.City = model.City;
            order.Street = model.Street;
            order.District = model.District;
            order.PostalCode = model.PostalCode;
            order.OrderLines = new List<OrderLine>();

            foreach (var item in cart.CartLines)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = item.Quantity;
                orderLine.Price = item.Product.Price * item.Quantity;
                orderLine.ProductId = item.Product.Id;
                order.OrderLines.Add(orderLine);

            }
            db.Orders.Add(order);
            db.SaveChanges();

        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetail());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetail model)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("No Product", "There are no products in your cart");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart,model);
                cart.Clear();
                return View("OrderCompleted");
            }
            else
            {
                return View(model);
            }
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult RemoveFromCart(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart; 
        }
    }
}