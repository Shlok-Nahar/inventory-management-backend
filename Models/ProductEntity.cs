using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class ProductEntity
    {
        [Key]
        public int productID { get; set; }
        public string productName { get; set; } = "";
        public int? supplierID { get; set; }
        public int? customerID { get; set; }
        public int stock { get; set; } = 0;

        public SupplierEntity supplierEntity { get; set; } = new SupplierEntity();
        public CustomerEntity customerEntity { get; set; } = new CustomerEntity();

        public ICollection<TransactionEntity> transactionEntities { get; set; } = new List<TransactionEntity>();
    }
}
