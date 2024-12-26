using InventoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public CustomersController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerEntity>> GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        // GET: api/Customers/{id}
        [HttpGet("{id}")]
        public ActionResult<CustomerEntity> GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return NotFound();

            return customer;
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<CustomerEntity> CreateCustomer([FromBody] CustomerEntity customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.customerID }, customer);
        }

        // PUT: api/Customers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerEntity customer)
        {
            if (id != customer.customerID)
                return BadRequest();

            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(c => c.customerID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Customers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
