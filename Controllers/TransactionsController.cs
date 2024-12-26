using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public TransactionsController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionEntity>>> GetTransactions() 
        {
            var transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }

        // GET: api/Transaction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionEntity>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return NotFound();

            return transaction;
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult<TransactionEntity>> CreateTransaction([FromBody] TransactionEntity transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.transactionID }, transaction);
        }

        // PUT: api/Transaction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionEntity transaction)
        {
            if (id != transaction.transactionID)
                return BadRequest();

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Transactions.AnyAsync(t => t.transactionID == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Transaction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return NotFound();

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
