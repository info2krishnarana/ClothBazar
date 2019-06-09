using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ShopController : Controller
    {
       // ProductService productService = new ProductService();

        public ActionResult Checkout()
        {
            CheckoutViewModel checkoutViewModel = new CheckoutViewModel();
            var CartProductCookie = Request.Cookies["CartProducts"];
            if (CartProductCookie != null)
            {
                checkoutViewModel.CartProductIds = CartProductCookie.Value.Split('-').Select(p => int.Parse(p)).ToList();
                checkoutViewModel.CartProducts = ProductService.Instance.GetProduct(checkoutViewModel.CartProductIds);
            }
            return View(checkoutViewModel);
        }
    }
}