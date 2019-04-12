using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> Categoryies { get; set; }
        public List<Product> Products { get; set; }
    }
}