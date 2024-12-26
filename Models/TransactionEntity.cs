using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement
{
    public class TransactionEntity
    {
        [Key]
        public int transactionID { get; set; }

        [ForeignKey("ProductEntity")]
        public int productID { get; set; }
        
        [ForeignKey("ProductEntity")]
        public string? productName { get; set; }

        [ForeignKey("CustomerEntity")]
        public int? customerID { get; set; }
        
        [ForeignKey("CustomerEntity")]
        public string? customerName { get; set; }

        [ForeignKey("SupplierEntity")]
        public int? supplierID { get; set; }
        
        [ForeignKey("SupplierEntity")]
        public string? supplierName { get; set; }
        public string? transactionType { get; set; }
        public int quantity { get; set; }
        public DateTime? transactionDate { get; set; }
        public ProductEntity? productEntity { get; set; }
        public SupplierEntity? supplierEntity { get; set; }
        public CustomerEntity? customerEntity { get; set; }

    }
}
