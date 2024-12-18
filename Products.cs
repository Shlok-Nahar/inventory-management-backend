namespace InventoryManagement
{
    public class Products
    {
        public int ProductID { get; set; }  // Primary key
        public string Name { get; set; } = "";
        public int? SupplierID { get; set; }
        public int? CustomerID { get; set; }

        public Suppliers Supplier { get; set; } = new Suppliers();
        public Customers Customer { get; set; } = new Customers();

        public ICollection<Transactions> Transactions { get; set; } = new List<Transactions>();
    }
}
