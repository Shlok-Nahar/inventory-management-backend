namespace InventoryManagement.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionEntity>> GetAllTransactionsAsync();
        Task<TransactionEntity> GetTransactionByIdAsync(int id);
        Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transaction);
        Task UpdateTransactionAsync(TransactionEntity transaction);
        Task DeleteTransactionAsync(int id);
        Task<IEnumerable<TransactionEntity>> GetTransactionsByProductIdAsync(int productId);
        Task<IEnumerable<TransactionEntity>> GetTransactionsByCustomerIdAsync(int customerId);
        Task<IEnumerable<TransactionEntity>> GetTransactionsBySupplierIdAsync(int supplierId);
    }
}
