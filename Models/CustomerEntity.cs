using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class CustomerEntity
    {
        [Key]
        public int customerID { get; set; }
        [Required]
        public string customerName { get; set; } = "";
        public string? contactInfo { get; set; }
        
        public ICollection<ProductEntity> productEntities { get; set; } = new List<ProductEntity>();
        public ICollection<TransactionEntity> transactionEntities { get; set; } = new List<TransactionEntity>();
    }
}
