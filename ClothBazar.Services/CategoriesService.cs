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
        #region Singleton     

        public static CategoriesService Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoriesService();
                return instance;
            }
        }
        private static CategoriesService instance { get; set; }

        private CategoriesService()
        { }

        #endregion

        public List<Category> GetCategories()
        {
            using (CBContext context = new CBContext())
            {
              return  context.Categories.ToList();
            }
        }
        public List<Category> GetFeaturedCategories()
        {
            using (CBContext context = new CBContext())
            {
                return context.Categories.Where(f => f.IsFeatured && f.ImageUrl != null).ToList();
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
