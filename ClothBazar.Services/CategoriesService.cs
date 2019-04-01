﻿using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class CategoriesService
    {
        public void SaveCategory(Category category)
        {
            using (CBContext context=new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
