using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockLevel { get; set; }

        public int SupplierID { get; set; }
        public Suppliers Suppliers { get; set; }
    }
}
