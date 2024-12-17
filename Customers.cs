using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string ContactInfo { get; set; }
    }
}