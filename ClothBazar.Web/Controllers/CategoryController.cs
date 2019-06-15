using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
      //  CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index()
        {
            List<Category> categories = CategoriesService.Instance.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            CategoriesService.Instance.SaveCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = CategoriesService.Instance.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CategoriesService.Instance.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Category category = CategoriesService.Instance.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            CategoriesService.Instance.DeleteCategory(category.Id);
            return RedirectToAction("Index");
        }
    }
}