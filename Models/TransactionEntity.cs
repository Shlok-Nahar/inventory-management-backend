using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class TransactionEntity
    {
        [Key]
        public int transactionID { get; set; }
        public int productID { get; set; }
        public string transactionType { get; set; } = "";
        public int quantity { get; set; }
        public DateTime date { get; set; }

        public ProductEntity productEntity { get; set; } = new ProductEntity();
    }
}
