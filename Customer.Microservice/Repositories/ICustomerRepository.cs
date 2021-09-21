using Customer.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel GetCustomerById(int id);
        void DeleteCustomer(int id);
        void InsertCustomer(CustomerModel customer);
        void UpdateCustomer(CustomerModel customer);
        void Save();
    }
}
