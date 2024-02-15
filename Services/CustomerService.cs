using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using WebApplication2.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers().ToList();
        }

        public Customer GetCustomerById(string id) {


            return _customerRepository.GetCustomerById(id);
        }

        public string DeleteCustomerById(string id)
        {


            return _customerRepository.DeleteCustomerById(id);
        }

        public string UpdateCustomerById(string id, string contactName)
        {
            return _customerRepository.UpdateCustomerById(id,contactName);
        }
    }
}