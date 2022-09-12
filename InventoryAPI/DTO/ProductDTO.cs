using Microsoft.Build.Framework;

namespace InventoryAPI.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
