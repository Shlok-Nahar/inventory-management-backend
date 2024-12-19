using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement
{
    public class ProductEntity
    {
        [Key]
        public int productID { get; set; }
        public string productName { get; set; } = "";

        [ForeignKey("SupplierEntity")]
        public int? supplierID { get; set; }
        [ForeignKey("CustomerEntity")]
        public int? customerID { get; set; }
        public float? price { get; set; }
        public int? stock { get; set; } = 0;

        public SupplierEntity? supplierEntity { get; set; }
        public CustomerEntity? customerEntity { get; set; }

        public ICollection<TransactionEntity> transactionEntities { get; set; } = new List<TransactionEntity>();
    }
}