using InventoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public ProductsController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductEntity>> GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductEntity> GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return product;
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<ProductEntity> CreateProduct([FromBody] ProductEntity product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new { id = product.productID }, product);
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductEntity product)
        {
            if (id != product.productID)
                return BadRequest();

            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.productID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
