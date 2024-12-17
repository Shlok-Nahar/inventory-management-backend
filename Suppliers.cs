using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string ContactInfo { get; set; }
    }
}