using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class Transactions
    {
        [Key]
        public int TransactionID { get; set; }

        public int ProductID { get; set; }
        public Products Product { get; set; }

        public TransactionType Type { get; set; }

        public int Quantity { get; set; }

        public DateTime Date { get; set; }
    }

    public enum TransactionType
    {
        Sale,
        Purchase
    }
}
