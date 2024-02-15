using WebApplication2.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface ICustomerService
    {
       
        public List<Customer> GetAllCustomers();

        public Customer GetCustomerById(string id);

        public string UpdateCustomerById(string id,string contactName);
        public string DeleteCustomerById(string id);

    }
}
