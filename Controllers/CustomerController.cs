using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Asp.Net_core_auth_task.Models;

namespace Asp.Net_core_auth_task.Controllers
{
    public class CustomersController : ControllerBase
    {
        [ApiController]
        [Route("customer")]
        [Authorize]
        public class CustomerController : ControllerBase
        {
            private readonly TokoKokoContext _context;
            public CustomerController(TokoKokoContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult GetCustomer()
            {
                var cu = _context.Customers;
                return Ok(new {message = "success retrieve data", status = true, data = cu});
            }

            [HttpPost]
            public IActionResult PostCustomer(Customer customer)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return Ok(customer);
            }

            [HttpGet("{id}")]
            public IActionResult GetCustomerById(int id)
            {
                var customer = _context.Customers.First(i => i.Id == id);
                return Ok(customer);
            }

            [HttpPut("{id}")]
            public IActionResult UpdateCustomer(int id)
            {
                var customer = _context.Customers.First(i => i.Id == id);
                customer.Full_name = "Na Dul Set";
                _context.SaveChanges();
                return Ok(customer);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteCustomer(int id)
            {
                var customer = _context.Customers.First(i => i.Id == id);
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return Ok(customer);
            }

                
        }
    }
}