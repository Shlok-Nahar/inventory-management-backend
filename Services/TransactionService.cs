using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly InventoryDbContext _context;

        public TransactionService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionEntity>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.Include(t => t.productEntity).ToListAsync();
        }

        public async Task<TransactionEntity> GetTransactionByIdAsync(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.productEntity)
                .FirstOrDefaultAsync(t => t.transactionID == id);
            if (transaction == null)
            {
                throw new KeyNotFoundException($"Transaction with ID {id} not found.");
            }
            return transaction;
        }

        public async Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task UpdateTransactionAsync(TransactionEntity transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TransactionEntity>> GetTransactionsByProductIdAsync(int productId)
        {
            return await _context.Transactions
                .Where(t => t.productID == productId)
                .Include(t => t.productEntity)
                .ToListAsync();
        }
    }
}
