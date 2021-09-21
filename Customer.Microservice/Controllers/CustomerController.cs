using Customer.Microservice.Models;
using Customer.Microservice.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return _repository.GetCustomers();
        }

        [HttpGet("{id}")]
        public CustomerModel Get(int id)
        {
            return _repository.GetCustomerById(id);
        }

        [HttpPost]
        public void Post([FromBody] CustomerModel customer)
        {
            _repository.InsertCustomer(customer);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] CustomerModel customer)
        {
            _repository.UpdateCustomer(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteCustomer(id);
        }
    }
}
