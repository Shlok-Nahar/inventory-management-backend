namespace InventoryManagement
{
    public class Suppliers
    {
        public int SupplierID { get; set; }  // Primary key
        public string Name { get; set; } = "";
        public string? ContactInfo { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
