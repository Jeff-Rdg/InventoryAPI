using Microsoft.Build.Framework;

namespace InventoryAPI.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
