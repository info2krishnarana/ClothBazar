using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class CategoriesService
    {
        public List<Category> GetCategories()
        {
            using (CBContext context = new CBContext())
            {
              return  context.Categories.ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using (CBContext context=new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public Category GetCategory(int id)
        {
            using (CBContext context = new CBContext())
            {
               return context.Categories.Find(id);
            }
        }

        public void UpdateCategory(Category category)
        {
            using (CBContext context = new CBContext())
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            using (CBContext context = new CBContext())
            {
                Category category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
