using ClothBazar.Entities;
using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
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
        CategoriesService categoriesService = new CategoriesService();
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
            List<Category> categories = categoriesService.GetCategories();
            return PartialView(categories);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModel  newCategoryViewModel)
        {
            Product newProduct = new Product();
            newProduct.Name = newCategoryViewModel.Name;
            newProduct.Description = newCategoryViewModel.Description;
            newProduct.Price = newCategoryViewModel.Price;
            //newProduct.CategoryID = newCategoryViewModel.CategoryID;
            newProduct.Category = categoriesService.GetCategory(newCategoryViewModel.CategoryID);
            productService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = productService.GetProduct(id);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return RedirectToAction("ProductTable");
        }
    }
}