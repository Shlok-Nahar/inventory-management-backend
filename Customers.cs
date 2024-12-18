namespace InventoryManagement
{
    public class Customers
    {
        public int CustomerID { get; set; }  // Primary key
        public string Name { get; set; }
        public string? ContactInfo { get; set; }
        
        public ICollection<Products> Products { get; set; } 
    }
}
