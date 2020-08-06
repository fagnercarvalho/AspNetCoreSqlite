using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSqlite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly Context context;

        public CustomerController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var maxId = 0;
            if (this.context.Customers.Any())
            {
                maxId = this.context.Customers.Max(c => c.Id);
            }

            var customer = new Customer { Id = maxId + 1, Name = $"Test {maxId + 1}" };

            context.Customers.Add(customer);

            context.SaveChanges();

            var customers = this.context.Customers.ToList();

            return customers;
        }
    }
}
