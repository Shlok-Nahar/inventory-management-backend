using InventoryManagement;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public SuppliersController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet]
        public ActionResult<IEnumerable<SupplierEntity>> GetSuppliers()
        {
            var suppliers = _context.Suppliers.ToList();
            return Ok(suppliers);
        }

        // GET: api/Suppliers/{id}
        [HttpGet("{id}")]
        public ActionResult<SupplierEntity> GetSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
                return NotFound();

            return supplier;
        }

        // POST: api/Suppliers
        [HttpPost]
        public ActionResult<SupplierEntity> CreateSupplier([FromBody] SupplierEntity supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.supplierID }, supplier);
        }

        // PUT: api/Suppliers/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSupplier(int id, [FromBody] SupplierEntity supplier)
        {
            if (id != supplier.supplierID)
                return BadRequest();

            _context.Entry(supplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Suppliers.Any(s => s.supplierID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Suppliers/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
                return NotFound();

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
