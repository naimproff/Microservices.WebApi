using Product.Microservice.Models;
using Product.Microservice.ProductContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
            }
        }

        public ProductModel GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void InsertProduct(ProductModel product)
        {
            if (product != null)
            {
                _context.Products.Add(product);
                Save();
            }
        }

        public void UpdateProduct(ProductModel product)
        {
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
