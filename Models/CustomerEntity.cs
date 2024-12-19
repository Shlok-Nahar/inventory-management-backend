using System.ComponentModel.DataAnnotations;

namespace InventoryManagement
{
    public class CustomerEntity
    {
        [Key]
        public int customerID { get; set; }
        public string customerName { get; set; } = "";
        public string? contactInfo { get; set; }
        
        public ICollection<ProductEntity> productEntities { get; set; } = new List<ProductEntity>();
    }
}
