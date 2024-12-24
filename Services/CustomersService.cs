using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly InventoryDbContext _context;

        public CustomersService(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }
            return customer;
        }

        public async Task<CustomerEntity> CreateProductAsync(CustomerEntity customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomerAsync(CustomerEntity customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public Task<CustomerEntity> CreateCustomerAsync(CustomerEntity customer)
        {
            throw new NotImplementedException();
        }
    }
}