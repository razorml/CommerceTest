using CommerceTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceTest.Controllers
{
    public class ProductController : Controller
    {
        private product product = new product();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.alert = "Info";
            ViewBag.regist = "Insert new product";
            ViewBag.category = product.GetCategory();
            return View(product.GetProducts());
        }
        [HttpPost]
        public ActionResult Index(string name, string description, string serial, string price, string category)
        {
            if (product.InsertProduct(name, description, serial, price, category))
            {
                ViewBag.alert = "Succes";
                ViewBag.regist = "product registered successfully";
            }
            else
            {
                ViewBag.alert = "Danger";
                ViewBag.regist = "product could not be registered";
            }
            ViewBag.category = product.GetCategory();
            return View(product.GetProducts());
        }

        public ActionResult EditProduct(int id)
        {
            ViewBag.alert = "info";
            ViewBag.regist = "Update Product";
            ViewBag.category = product.GetCategory();
            return View(product.GetProductId(id));
        }

        [HttpPost]
        public ActionResult EditProduct(string id, string name, string description, string serial, string price, string category)
        {
            if (product.UpdateProduct(id,name, description, serial, price, category))
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.alert = "Danger";
                ViewBag.regist = "product could not be update";
            }
            ViewBag.category = product.GetCategory();
            return View(product.GetProducts());
        }

        public ActionResult DeleteProduct(int id) 
        {
            if(product.DeleteProduct(id)) 
            {
                return RedirectToAction("Index", "Product");                  
            }
            else
            {
                ViewBag.alert = "Danger";
                ViewBag.regist = "product could not be delete";
            }
            ViewBag.category = product.GetCategory();
            return View(product.GetProducts());
        }
    }
}