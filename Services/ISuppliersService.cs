namespace InventoryManagement.Services
{
    public interface ISuppliersService
    {
        Task<IEnumerable<SupplierEntity>> GetAllSuppliersAsync();
        Task<SupplierEntity> GetSupplierByIdAsync(int id);
        Task<SupplierEntity> CreateSupplierAsync(SupplierEntity supplier);
        Task UpdateSupplierAsync(SupplierEntity supplier);
        Task DeleteSupplierAsync(int id);
    }
}