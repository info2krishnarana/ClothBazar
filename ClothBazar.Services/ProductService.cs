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
    public class ProductService
    {
        #region Singleton     
        
        public static ProductService Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductService();
                return instance;
            }
        }
        private static ProductService instance { get; set; }

        private ProductService()
        { }

        #endregion

        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 5;
            using (CBContext context = new CBContext())
            {
                return context.Products.OrderBy(p => p.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(cat => cat.Category).ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            using (CBContext context = new CBContext())
            {
                context.Entry(product.Category).State = EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
            using (CBContext context = new CBContext())
            {
                return context.Products.Find(id);
            }
        }

        public void UpdateProduct(Product product)
        {
            using (CBContext context = new CBContext())
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (CBContext context = new CBContext())
            {
                Product product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetProduct(List<int> ids)
        {
            using (CBContext context = new CBContext())
            {
                return context.Products.Where(p => ids.Contains(p.Id)).ToList();
            }
        }
    }
}
