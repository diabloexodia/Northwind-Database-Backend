using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService c)
        {
            _customerService = c;
        }

        [HttpGet]
        public IActionResult actionResult()
        {
            List<Customer> l = _customerService.GetAllCustomers();
            return Ok(l);
        }


        [HttpGet("id")]

        public IActionResult Get(string id) { 

            Customer  l= _customerService.GetCustomerById(id);    
            return Ok(l);

        }


        [HttpDelete("id")]

        public IActionResult Delete(string id)
        {

            string l = _customerService.DeleteCustomerById(id);
            return Ok(l);

        }

        [HttpPut("{id}/{contactName}")]
        public ActionResult Put(string id, string contactName)
        {
            string response = _customerService.UpdateCustomerById(id, contactName);
            return Ok(response);
        }


    }
}
