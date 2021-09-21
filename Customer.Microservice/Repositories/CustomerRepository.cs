using Customer.Microservice.Contexts;
using Customer.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;
        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            _dbContext.Customers.Remove(customer);
            Save();
        }

        public CustomerModel GetCustomerById(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            return customer;
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _dbContext.Customers.ToList();
            
        }

        public void InsertCustomer(CustomerModel customer)
        {
            _dbContext.Customers.Add(customer);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            _dbContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
