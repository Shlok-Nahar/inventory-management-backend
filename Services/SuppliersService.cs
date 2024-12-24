using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly InventoryDbContext _context;

        public SuppliersService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplierEntity>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<SupplierEntity> GetSupplierByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                throw new KeyNotFoundException($"Supplier with ID {id} not found.");
            }
            return supplier;
        }

        public async Task<SupplierEntity> CreateSupplierAsync(SupplierEntity supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task UpdateSupplierAsync(SupplierEntity supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }

        public Task<CustomerEntity> CreateCustomerAsync(CustomerEntity customer)
        {
            throw new NotImplementedException();
        }
    }
}