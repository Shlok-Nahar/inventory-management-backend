namespace InventoryManagement
{
    public class Products
    {
        public int ProductID { get; set; }  // Primary key
        public string Name { get; set; }
        public int? SupplierID { get; set; }
        public int? CustomerID { get; set; }

        public Suppliers Supplier { get; set; }
        public Customers Customer { get; set; }

        public ICollection<Transactions> Transactions { get; set; } = new List<Transactions>();
    }
}
