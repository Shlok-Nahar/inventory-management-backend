using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class SupplierEntity
    {
        [Key]
        public int supplierID { get; set; }
        [Required]
        public string supplierName { get; set; } = "";
        public string? contactInfo { get; set; }

        public ICollection<ProductEntity> productEntities { get; set; } = new List<ProductEntity>();
        public ICollection<TransactionEntity> transactionEntities { get; set; } = new List<TransactionEntity>();
    }
}
