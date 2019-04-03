using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
        {
            List<Product> products = productService.GetProducts();
            if (!string.IsNullOrEmpty(search))
            {
                products = productService.GetProducts().Where(sr => sr.Name == search).ToList();
            }
            return PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            productService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }
    }
}