namespace InventoryManagement.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync();
        Task<CustomerEntity> GetCustomerByIdAsync(int id);
        Task<CustomerEntity> CreateCustomerAsync(CustomerEntity customer);
        Task UpdateCustomerAsync(CustomerEntity customer);
        Task DeleteCustomerAsync(int id);
    }
}