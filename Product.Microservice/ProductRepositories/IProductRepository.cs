using Product.Microservice.Models;
using Product.Microservice.ProductContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.ProductRepositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetProductById(int id);
        void DeleteProduct(int id);
        void InsertProduct(ProductModel product);
        void UpdateProduct(ProductModel product);
        void Save();
    }
}
