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
        public string? transactionType { get; set; }
        public int quantity { get; set; }
        public DateTime? transactionDate { get; set; }

        public ProductEntity? productEntity { get; set; }
    }
}
