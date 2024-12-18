namespace InventoryManagement
{
    public class Transactions
    {
        public int TransactionID { get; set; }  // Primary key
        public int ProductID { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public Products Product { get; set; }
    }
}
