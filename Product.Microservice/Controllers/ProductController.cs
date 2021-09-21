using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Models;
using Product.Microservice.ProductRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository product)
        {
            _repository = product;
        }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            var product = _repository.GetProducts();
            return product;
        }
       
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            var product = _repository.GetProductById(id);
            return product;
        }

        [HttpPost]
        public void Post([FromBody] ProductModel product)
        {
            using (var scope = new TransactionScope())
            {
                _repository.InsertProduct(product);
                scope.Complete();
                //return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
        }

        [HttpPut("{id}")]
        public void Put([FromBody] ProductModel product)
        {
            if (product != null)
            {
                using (var scope = new TransactionScope())
                {
                    _repository.UpdateProduct(product);
                    scope.Complete();
                    //return new OkObjectResult(product);
                }
            }
            //return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteProduct(id);
        }
    }
}
